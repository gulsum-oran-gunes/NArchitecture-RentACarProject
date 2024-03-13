using Application.Features.Models.Dtos;
using Application.Features.Models.Queries;
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

namespace Application.Features.Models.Queries
{
    public class GetAllModelQueryHandler :IRequestHandler <GetAllModelQuery, List< GetAllModelResponse>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetAllModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllModelResponse>> Handle(GetAllModelQuery request, CancellationToken cancellationToken)
        {
            List<Model> models = await _modelRepository.GetAllAsync();
            List<GetAllModelResponse> responses = _mapper.Map<List<GetAllModelResponse>>(models);
            return responses;
        }

       
    }
}
