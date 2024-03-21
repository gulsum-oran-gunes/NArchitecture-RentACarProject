using Application.Features.CarImages.Commands.Create;
using Application.Features.CarImages.Commands.Delete;
using Application.Features.CarImages.Commands.Update;
using Application.Features.CarImages.Dtos;
using Application.Features.CarImages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarImages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CarImage, CreateCarImageCommand>().ReverseMap();
            CreateMap<CarImage, CreatedCarImageResponse>().ReverseMap();
            CreateMap<CarImage, UpdateCarImageCommand>().ReverseMap();
            CreateMap<CarImage, UpdatedCarImageResponse>().ReverseMap();
            CreateMap<CarImage, DeleteCarImageCommand>().ReverseMap();
            CreateMap<CarImage, DeletedCarImageResponse>().ReverseMap();
            CreateMap<CarImage, GetByIdCarImageResponse>().ReverseMap();
            CreateMap<CarImage, GetByCarIdResponse>().ReverseMap();
            CreateMap<CarImage, GetListCarImageResponse>().ReverseMap();
            


        }
    }

}
