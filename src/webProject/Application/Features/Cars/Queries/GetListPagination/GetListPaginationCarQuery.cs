using Application.Features.Cars.Models;
using Application.Requests;
using Core.Application.Pipelines.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetListPagination
{
    public class GetListPaginationCarQuery : IRequest<CarListModel>, ICachableRequest
    {
    public PageRequest PageRequest { get; set; }
    public bool BypassCache { get; }

    public string CacheKey => "car-list";

    public TimeSpan? SlidingExpiration { get; }
    }

}
    

