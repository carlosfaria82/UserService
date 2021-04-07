using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Application.Services;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IActionResult> Get()
        {
            var result = await _userMgmtService.GetAllAsync();
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }       
    }
}
