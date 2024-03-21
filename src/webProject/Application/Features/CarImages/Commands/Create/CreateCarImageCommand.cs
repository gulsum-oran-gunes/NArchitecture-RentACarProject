using Application.Features.CarImages.Dtos;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarImages.Commands.Create
{
    public class CreateCarImageCommand : IRequest<CreatedCarImageResponse>, IIntervalRequest, ILoggableRequest, ICacheRemoverRequest
    {
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public int Interval => 1;
        public bool BypassCache { get; }
        public string CacheKey => "carimage-list";
    }


}
    
