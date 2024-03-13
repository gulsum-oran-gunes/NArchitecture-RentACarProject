using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries
{
    public class GetAllBrandQueryHandler :IRequestHandler<GetAllBrandQuery, List<GetAllBrandResponse>>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public GetAllBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllBrandResponse>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            List<Brand> brands = await _brandRepository.GetAllAsync();
            List<GetAllBrandResponse> responses = _mapper.Map<List<GetAllBrandResponse>>(brands);
            return responses;
        }
    }

    
}
