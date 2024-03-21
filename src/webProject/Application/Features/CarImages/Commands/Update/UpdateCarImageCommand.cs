using Amazon.Runtime.Internal;
using Application.Features.CarImages.Dtos;
using Core.Application.Pipelines.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarImages.Commands.Update
{
    public class UpdateCarImageCommand : IRequest<UpdatedCarImageResponse>, ICacheRemoverRequest
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public bool BypassCache { get; }
        public string CacheKey => "carimage-list";
    }
}
