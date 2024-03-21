using Application.Features.CarImages.Dtos;
using Application.Features.CarImages.Queries.GetById;
using Application.Services.CarImageService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarImages.Queries.GetByCarId
{
    public class GetByCarIdQueryHandler : IRequestHandler<GetByCarIdQuery,GetByCarIdResponse>
    {
        private readonly ICarImageRepository _carImageRepository;
        private readonly IMapper _mapper;
        private readonly CarImageBusinessRules _businessRules;

        public GetByCarIdQueryHandler(ICarImageRepository carImageRepository, IMapper mapper, CarImageBusinessRules businessRules)
        {
            _carImageRepository = carImageRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<GetByCarIdResponse> Handle(GetByCarIdQuery request, CancellationToken cancellationToken)
        {
            await _businessRules.CarImageCarIdShouldExistsWhenSelected(request.CarId);
            await _businessRules.CheckIfCarImageNull(request.CarId);
            CarImage carImage = await _carImageRepository.GetAsync(x => x.CarId == request.CarId);
            GetByCarIdResponse response = _mapper.Map<GetByCarIdResponse>(carImage);
            return response;

        }
       

    }
}
