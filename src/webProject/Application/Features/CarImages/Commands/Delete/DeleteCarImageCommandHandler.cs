using Application.Features.CarImages.Commands.Delete;
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

namespace Application.Features.CarImages.Commands.Delete
{
    public class DeleteCarImageCommandHandler : IRequestHandler<DeleteCarImageCommand, DeletedCarImageResponse>
    {
        private readonly ICarImageRepository _carImageRepository;
        private readonly IMapper _mapper;

        public DeleteCarImageCommandHandler(ICarImageRepository carImageRepository, IMapper mapper)
        {
            _carImageRepository = carImageRepository;
            _mapper = mapper;
        }

        public async Task<DeletedCarImageResponse> Handle(DeleteCarImageCommand request, CancellationToken cancellationToken)
        {
            CarImage carImage = await _carImageRepository.GetAsync(x => x.Id == request.Id);
            CarImage deletedCarImage = await _carImageRepository.DeleteAsync(carImage);
            DeletedCarImageResponse deletedCarImageResponse = _mapper.Map<DeletedCarImageResponse>(deletedCarImage);
            return deletedCarImageResponse;
        }


    }
}
