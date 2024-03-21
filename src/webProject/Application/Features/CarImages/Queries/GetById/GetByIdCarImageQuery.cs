using Amazon.Runtime.Internal;
using Application.Features.CarImages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarImages.Queries.GetById
{
    public class GetByIdCarImageQuery :IRequest<GetByIdCarImageResponse>
    {
        public int Id { get; set; }
    }
}
