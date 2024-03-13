

using Application.Features.Models.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.Delete
{
    public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, DeletedModelResponse>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public DeleteModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<DeletedModelResponse> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            Model model = await _modelRepository.GetAsync(x => x.Id == request.Id);
            Model deletedModel = await _modelRepository.DeleteAsync(model);
            DeletedModelResponse deletedModelResponse = _mapper.Map<DeletedModelResponse>(deletedModel);
            return deletedModelResponse;
        }
    }
}
