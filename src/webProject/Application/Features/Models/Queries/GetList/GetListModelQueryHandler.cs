using Application.Features.Models.Dtos;
using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetList
{
    public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, List<GetListModelResponse>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetListModelResponse>> Handle(GetListModelQuery request, CancellationToken cancellationToken)
        {
            List<Model> models = await _modelRepository.GetAllAsync();
            List<GetListModelResponse> responses = _mapper.Map<List<GetListModelResponse>>(models);
            return responses;
        }


    }
}
