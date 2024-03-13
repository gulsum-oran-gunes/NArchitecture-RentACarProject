﻿using Application.Features.Brands.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries
{
    public class GetAllBrandQuery:IRequest<List<GetAllBrandResponse>>
    {
    }
}
