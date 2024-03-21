using Application.Features.CarImages.Dtos;

using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarImages.Queries.GetById
{
    public class GetByIdCarImageQueryHandler : IRequestHandler<GetByIdCarImageQuery, GetByIdCarImageResponse>
    {
        private readonly ICarImageRepository _carImageRepository;
        private readonly IMapper _mapper;

        public GetByIdCarImageQueryHandler(ICarImageRepository carImageRepository, IMapper mapper)
        {
            _carImageRepository = carImageRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCarImageResponse> Handle(GetByIdCarImageQuery request, CancellationToken cancellationToken)
        {
            CarImage carImage = await _carImageRepository.GetAsync(x => x.Id == request.Id);
            GetByIdCarImageResponse response = _mapper.Map<GetByIdCarImageResponse>(carImage);
            return response;
        }
    }
}
