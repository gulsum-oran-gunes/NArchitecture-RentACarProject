using Application.Features.CarImages.Commands.Update;
using Application.Features.CarImages.Dtos;
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

namespace Application.Features.CarImages.Commands.Update
{
    public class UpdateCarImageCommandHandler : IRequestHandler<UpdateCarImageCommand, UpdatedCarImageResponse>
    {
        private readonly ICarImageRepository _carImageRepository;
        private readonly IMapper _mapper;

        public UpdateCarImageCommandHandler(ICarImageRepository carImageRepository, IMapper mapper)
        {
            _carImageRepository = carImageRepository;
            _mapper = mapper;
        }
        public async Task<UpdatedCarImageResponse> Handle(UpdateCarImageCommand request, CancellationToken cancellationToken)
        {
            CarImage carImage = await _carImageRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, carImage);
            CarImage updatedCarImage = await _carImageRepository.UpdateAsync(carImage);
            UpdatedCarImageResponse response = _mapper.Map<UpdatedCarImageResponse>(updatedCarImage);
            return response;
        }
    }
}
