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

namespace Application.Features.CarImages.Queries.GetList
{
    public class GetListCarImageQueryHandler : IRequestHandler<GetListCarImageQuery, List<GetListCarImageResponse>>

    {
        private readonly ICarImageRepository _carImageRepository;
        private readonly IMapper _mapper;

        public GetListCarImageQueryHandler(ICarImageRepository carImageRepository, IMapper mapper)
        {
            _carImageRepository = carImageRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListCarImageResponse>> Handle(GetListCarImageQuery request, CancellationToken cancellationToken)
        {
            List<CarImage> carImages = await _carImageRepository.GetAllAsync();
            List<GetListCarImageResponse> responses = _mapper.Map<List<GetListCarImageResponse>>(carImages);
            return responses;
        }
    }



}

