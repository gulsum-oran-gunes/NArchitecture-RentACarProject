using Application.Features.Brands.Dtos;
using Application.Features.Cars.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetList
{
    public class GetListCarQuery : IRequest<List<GetListCarResponse>>
    {
    }
}
