using Application.Features.CarImages.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarImages.Commands.Delete
{
    public class DeleteCarImageCommand : IRequest<DeletedCarImageResponse>, ICacheRemoverRequest
    {
        public int Id { get; set; }
        public bool BypassCache { get; }
        public string CacheKey => "carimages-list";
    }
    
}
