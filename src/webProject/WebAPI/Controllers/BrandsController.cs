using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries;
using Application.Features.Brands.Queries.GetListDynamic;
using Application.Features.Brands.Queries.GetListPagination;
using Application.Requests;
using Core.Persistence.Dynamic;
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

        [HttpGet("pagination")]
        public async Task<IActionResult> GetListPagination([FromQuery] PageRequest pageRequest)
        {
            GetListPaginationBrandQuery query = new() { PageRequest = pageRequest };
            BrandListModel result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("dynamic")]
        public async Task<IActionResult> GetListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListBrandDynamicQuery brandDynamicQuery = new() { PageRequest = pageRequest, Dynamic = dynamic };
            BrandListModel result = await Mediator.Send(brandDynamicQuery);
            return Ok(result);
        }
    }
}
