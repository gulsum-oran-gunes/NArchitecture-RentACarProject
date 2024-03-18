using Application.Features.Cars.Models;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetListDynamic;
using Application.Features.Cars.Queries.GetListPagination;
using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetById;
using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListDynamic;
using Application.Features.Models.Queries.GetListPagination;
using Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateModelCommand command)
        {
            return Created("", await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteModelCommand command)
        {
            return Created("", await Mediator.Send(command));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateModelCommand command)
        {
            return Created("", await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            return Created("", await Mediator.Send(new GetListModelQuery()));
        }

        [HttpGet("GetByIdModel", Name = "GetByIdModel")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdModelQuery query)
        {
            return Created("", await Mediator.Send(query));
        }
        [HttpGet("Pagination")]
        public async Task<IActionResult> GetListPagination([FromQuery] PageRequest pageRequest)
        {
            GetListPaginationModelQuery query = new() { PageRequest = pageRequest };
            ModelListModel result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("Dynamic")]
        public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListModelDynamicQuery modelDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            ModelListModel result = await Mediator.Send(modelDynamicQuery);
            return Ok(result);
        }
    }
}

