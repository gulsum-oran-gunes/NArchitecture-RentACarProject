using Application.Features.Cars.Dtos;
using Application.Features.Cars.Queries;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries
{
    public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQuery, GetByIdCarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetByIdCarQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCarResponse> Handle(GetByIdCarQuery request, CancellationToken cancellationToken)
        {
            Car car = await _carRepository.GetAsync(x => x.Id == request.Id);
            GetByIdCarResponse response = _mapper.Map<GetByIdCarResponse>(car);
            return response;
        }
       
    }
}
