using Billing.Authentication.Business.Interface;
using Billing.Authentication.Domains.Entities;
using Billing.Authentication.Domains.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Billing.Authentication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServiceAsync _service;

        public UserController(IUserServiceAsync userServiceAsync)
        {
            _service = userServiceAsync;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromQuery] Login login)
        {
            var response = await _service.LoginAsync(login);
            
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var response = await _service.CreateAsync(user);
            if (response.IsSuccess) 
                return Ok(user);

            return BadRequest(response);
        }
    }
}
