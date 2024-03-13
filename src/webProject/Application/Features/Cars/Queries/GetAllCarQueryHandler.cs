using Application.Features.Cars.Dtos;
using Application.Features.Cars.Queries;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries
{
    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, List<GetAllCarResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetAllCarQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCarResponse>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            List<Car> cars = await _carRepository.GetAllAsync();
            List<GetAllCarResponse> responses = _mapper.Map<List<GetAllCarResponse>>(cars);
            return responses;
        }
    }
}
