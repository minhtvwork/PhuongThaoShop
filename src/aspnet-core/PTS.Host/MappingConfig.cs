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
                config.CreateMap<ColorDto, ColorEntity>().ReverseMap();
                config.CreateMap<VoucherDto, VoucherEntity>().ReverseMap();
                config.CreateMap<ContactDto, ContactEntity>().ReverseMap();
                config.CreateMap<CreateProductDetailDto, ProductDetailEntity>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
