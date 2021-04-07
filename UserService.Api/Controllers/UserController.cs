using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Application.Dtos;
using UserService.Application.Services;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController 
        : ControllerBase
    {
        private readonly IUserMgmtService _userMgmtService;
        private readonly ILogger<UserController> _logger;

        public UserController(
            IUserMgmtService userMgmtService,
            ILogger<UserController> logger)
        {
            _userMgmtService = userMgmtService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            var result = await _userMgmtService.GetAllAsync();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var result = await _userMgmtService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post(UserDto userDto)
        {
            var user = await _userMgmtService.CreateAsync(userDto);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserDto userDto)
        {
            if(id != userDto.Id)
            {
                return BadRequest();
            }

            if (!_userMgmtService.UserExists(id))
            {
                return NotFound();
            }

            try
            {
                await _userMgmtService.UpdateAsync(id, userDto);
            }
            catch (DbUpdateConcurrencyException) when (!_userMgmtService.UserExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_userMgmtService.UserExists(id))
            {
                return NotFound();
            }

            await _userMgmtService.DeleteAsync(id);

            return NoContent();
        }
    }
}
