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
    public class GetByIdModelQueryHandler :IRequestHandler<GetByIdModelQuery, GetByIdModelResponse>
    {

        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public GetByIdModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdModelResponse> Handle(GetByIdModelQuery request, CancellationToken cancellationToken)
        {
            Model model = await _modelRepository.GetAsync(x => x.Id == request.Id);
            GetByIdModelResponse response = _mapper.Map<GetByIdModelResponse>(model);
            return response;
        }

       
    }
}
