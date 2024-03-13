using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateCarCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteCarCommand command)
        {
            return Created("", await Mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateCarCommand command)
        {
            return Created("", await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Created("", await Mediator.Send(new GetAllCarQuery()));
        }

        [HttpGet("GetByIdCar", Name = "GetByIdCar")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdCarQuery query)
        {
            return Created("", await Mediator.Send(query));
        }
    }
}

