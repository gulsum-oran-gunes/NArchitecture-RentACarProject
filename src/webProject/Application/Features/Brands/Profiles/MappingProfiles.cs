﻿using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
            CreateMap<Brand, UpdateBrandCommand>().ReverseMap();
            CreateMap<Brand, UpdatedBrandResponse>().ReverseMap();
            CreateMap<Brand, DeleteBrandCommand>().ReverseMap();
            CreateMap<Brand, DeletedBrandResponse>().ReverseMap();
            CreateMap<Brand, GetByIdBrandResponse>().ReverseMap();
            CreateMap<Brand, GetAllBrandResponse>().ReverseMap();
            CreateMap<Brand, GetListBrandResponse>().ReverseMap();
            CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();


        }
    }
}
