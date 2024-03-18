using Application.Features.Cars.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetList
{
    public class GetListCarQueryHandler : IRequestHandler<GetListCarQuery, List<GetListCarResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetListCarQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListCarResponse>> Handle(GetListCarQuery request, CancellationToken cancellationToken)
        {
            List<Car> cars = await _carRepository.GetAllAsync();
            List<GetListCarResponse> responses = _mapper.Map<List<GetListCarResponse>>(cars);
            return responses;
        }
    }
}
