using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommandHandler:IRequestHandler<DeleteBrandCommand,DeletedBrandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = await _brandRepository.GetAsync(x => x.Id == request.Id);
            Brand deletedBrand = await _brandRepository.DeleteAsync(brand);
            DeletedBrandResponse deletedBrandResponse = _mapper.Map<DeletedBrandResponse>(deletedBrand);
            return deletedBrandResponse;
        }

        
    }
}
