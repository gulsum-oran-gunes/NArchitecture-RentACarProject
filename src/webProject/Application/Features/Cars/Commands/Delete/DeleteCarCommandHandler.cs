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

namespace Application.Features.Cars.Commands.Delete
{
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeletedCarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<DeletedCarResponse> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            Car car = await _carRepository.GetAsync(x => x.Id == request.Id);
            Car deletedCar = await _carRepository.DeleteAsync(car);
            DeletedCarResponse deletedCarResponse = _mapper.Map<DeletedCarResponse>(deletedCar);
            return deletedCarResponse;

        }
    }
}
