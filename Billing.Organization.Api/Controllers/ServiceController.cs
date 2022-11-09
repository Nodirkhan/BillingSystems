using Billing.Organization.Business.Interface;
using Billing.Organization.Domains.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Billing.Organization.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceServiceAsync _service;

        public ServiceController(IServiceServiceAsync service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _service.GetAll();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetPageListAsync([FromQuery] int pageNumber, int pageSize)
        {
            var response = await _service.GetPageListAsync(pageNumber, pageSize);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPageListAsync([FromQuery] Guid id)
        {
            var response = await _service.GetById(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            var response = await _service.GetById(id);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ServiceForCreateDTO model)
        {
            var response = await _service.Create(model);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ServiceForUpdateDTO model)
        {
            var response = await _service.Update(model);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var response = await _service.Delete(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}
