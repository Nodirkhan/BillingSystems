using Billing.UserApi.Business.Interface;
using Billing.UserApi.Domains.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Billing.UserApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServiceAsync _userService;

        public UserController(IUserServiceAsync userServiceAsync)
        {
            _userService = userServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _userService.GetAllAsync();

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserForCreationDTO userDto)
        {
            var response = await _userService.CreateAsync(userDto);
           
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var response = await _userService.GetOneAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetPageListAsync([FromQuery] int pageNumber, int pageSize)
        {
            var response = await _userService.GetPageListAsync(pageNumber, pageSize);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UserForModifiedDTO userDto)
        {
            var response = await _userService.Update(userDto);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var response = await _userService.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }

    }
}
