﻿using Application.Features.Brands.Models;
using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, CreateModelCommand>().ReverseMap();
            CreateMap<Model, CreatedModelResponse>().ReverseMap();
            CreateMap<Model, UpdateModelCommand>().ReverseMap();
            CreateMap<Model, UpdatedModelResponse>().ReverseMap();
            CreateMap<Model, DeleteModelCommand>().ReverseMap();
            CreateMap<Model, DeletedModelResponse>().ReverseMap();
            CreateMap<Model, GetByIdModelResponse>().ReverseMap();
            CreateMap<Model, GetListModelResponse>().ReverseMap();
            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();
           


        }
    }
}
