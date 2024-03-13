﻿using Application.Features.Brands.Dtos;
using Application.Features.Cars.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries
{
    public class GetAllCarQuery : IRequest<List<GetAllCarResponse>>
    {
    }
}
