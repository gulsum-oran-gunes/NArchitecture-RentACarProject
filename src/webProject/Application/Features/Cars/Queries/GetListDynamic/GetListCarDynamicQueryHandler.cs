using Application.Features.Cars.Models;
using Application.Features.Cars.Queries.GetListDynamic;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Queries.GetListDynamic
{
    public class GetListCarDynamicQueryHandler : IRequestHandler<GetListCarDynamicQuery, CarListModel>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetListCarDynamicQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CarListModel> Handle(GetListCarDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Car> cars = await _carRepository.GetListByDynamicAsync(request.Dynamic, index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
            CarListModel CarListModel = _mapper.Map<CarListModel>(cars);
            return CarListModel;
        }
    }
}
