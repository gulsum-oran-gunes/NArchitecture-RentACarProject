using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateBrandCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteBrandCommand command)
        {
            return Created("", await Mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateBrandCommand command)
        {
            return Created("", await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Created("", await Mediator.Send(new GetAllBrandQuery()));
        }

        [HttpGet("GetByIdBrand", Name = "GetByIdBrand")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdBrandQuery query)
        {
            return Created("", await Mediator.Send(query));
        }
    }
}
