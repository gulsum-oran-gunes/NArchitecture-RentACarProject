using Application.Features.Brands.Dtos;
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

namespace Application.Features.Cars.Commands.Update
{
    public class UpdateCarCommandHandler:IRequestHandler<UpdateCarCommand,UpdatedCarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public UpdateCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedCarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = await _carRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, car);
            Car updatedCar = await _carRepository.UpdateAsync(car);
            UpdatedCarResponse response = _mapper.Map<UpdatedCarResponse>(updatedCar);
            return response;
        }
    }
}
