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

namespace Application.Features.CarImages.Commands.Create
{
    public class CreateCarImageCommandHandler : IRequestHandler<CreateCarImageCommand, CreatedCarImageResponse>

    {
        private readonly ICarImageRepository _carImageRepository;
        private readonly IMapper _mapper;

        public CreateCarImageCommandHandler(ICarImageRepository carImageRepository, IMapper mapper)
        {
            _carImageRepository = carImageRepository;
            _mapper = mapper;
        }

        public async Task<CreatedCarImageResponse> Handle(CreateCarImageCommand request, CancellationToken cancellationToken)
        {
            CarImage mappedCarImage = _mapper.Map<CarImage>(request);
            CarImage createdCarImage = await _carImageRepository.AddAsync(mappedCarImage);
            CreatedCarImageResponse createdCarImageResponse = _mapper.Map<CreatedCarImageResponse>(createdCarImage);
            return createdCarImageResponse;
        }
    }
}
