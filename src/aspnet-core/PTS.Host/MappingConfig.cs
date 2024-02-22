﻿using AutoMapper;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
namespace PTS.Host
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, ProductEntity>().ReverseMap();
                config.CreateMap<CpuDto, CpuEntity>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}