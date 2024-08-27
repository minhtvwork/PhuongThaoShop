﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.DTOs;
using PTS.Application.Extensions;
using PTS.Application.Features.ProductDetail.DTOs;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Enums;
using PTS.Domain.Entities;
using PTS.Shared;

namespace PTS.Application.Features.ProductDetail.Queries
{
    public record ProductDetailGetPageQuery : BaseGetPageQuery, IRequest<PaginatedResult<ProductDetailGetPageDto>>
    {
      
    }

    internal class ProductDetailGetPagesQueryHandler : IRequestHandler<ProductDetailGetPageQuery, PaginatedResult<ProductDetailGetPageDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public ProductDetailGetPagesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ISender sender)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sender = sender;
        }

        public async Task<PaginatedResult<ProductDetailGetPageDto>> Handle(ProductDetailGetPageQuery queryInput, CancellationToken cancellationToken)
        {
            try
            {
                var image = _unitOfWork.Repository<ImageEntity>().Entities.AsNoTracking();
                var query = (from a in _unitOfWork.Repository<ProductDetailEntity>().Entities.Where(x => x.Status != (int)StatusEnum.Delete).AsNoTracking()
                             join pImage in _unitOfWork.Repository<ProductDetailImage>().Entities.Where(x => x.IsIndex).AsNoTracking()
                                  on a.Id equals pImage.ProductDetailId into pImageGroup
                             from pImage in pImageGroup.DefaultIfEmpty()
                             select new ProductDetailGetPageDto
                             {
                                 Id = a.Id,
                                 Code = a.Code,
                                 Price = a.Price,
                                 Status = a.Status,
                                 Upgrade = a.Upgrade,
                                 Description = a.Description,
                                 CrDateTime = a.CrDateTime,
                                 AvailableQuantity = 0,
                                 ProductEntityId = a.ProductEntityId,
                                 ColorEntityId = a.ColorEntityId,
                                 RamEntityId = a.RamEntityId,
                                 CpuEntityId = a.CpuEntityId,
                                 HardDriveEntityId = a.HardDriveEntityId,
                                 ScreenEntityId = a.ScreenEntityId,
                                 CardVGAEntityId = a.CardVGAEntityId,
                                 DiscountId = a.DiscountId,
                                 Discount = a.Discount != null ? a.Discount.Percentage : 0,
                                 ThongSoRam = a.RamEntity.ThongSo,
                                 MaRam = a.RamEntity.Ma,
                                 TenCpu = a.CpuEntity.Ten,
                                 MaCpu = a.CpuEntity.Ma,
                                 ThongSoHardDrive = a.HardDriveEntity.ThongSo,
                                 MaHardDrive = a.HardDriveEntity.Ma,
                                 NameColor = a.ColorEntity.Name,
                                 MaColor = a.ColorEntity.Ma,
                                 MaCardVGA = a.CardVGAEntity.Ma,
                                 TenCardVGA = a.CardVGAEntity.Ten,
                                 ThongSoCardVGA = a.CardVGAEntity.ThongSo,
                                 MaManHinh = a.ScreenEntity.Ma,
                                 KichCoManHinh = a.ScreenEntity.KichCo,
                                 TanSoManHinh = a.ScreenEntity.TanSo,
                                 ChatLieuManHinh = a.ScreenEntity.ChatLieu,
                                 NameProduct = a.ProductEntity.Name,
                                 NameProductType = a.ProductEntity.ProductTypeEntity.Name,
                                 ManufacturerEntityId = a.ProductEntity.ManufacturerEntityId,
                                 NameManufacturer = a.ProductEntity.ManufacturerEntity.Name,
                                 NewPrice = a.Price - (a.Discount != null? a.Discount.Percentage:0),
                                 PhanTramGiamGia = a.Discount != null && a.Price != 0 ? Convert.ToInt32((a.Discount.Percentage / a.Price) * 100) : 0,
                                 IdImage = pImage != null ? pImage.ImageId : 0
                             });
              
                var result = await query.ToPaginatedListAsync(queryInput.Page, queryInput.PageSize, cancellationToken);
                if (result.Data != null && result.Data.Any())
                {
                    int index = (queryInput.Page - 1) * queryInput.PageSize + 1;
                    foreach (var item in result.Data)
                    {
                        item.Stt = index++;
                        if(item.Status == 1)
                        {
                            item.StrStatus = "Đang hoạt động";
                        }
                        else if (item.Status == 2)
                        {
                            item.StrStatus = "Ẩn";
                        }
                        else if (item.Status == 3)
                        {
                            item.StrStatus = "Ngừng kinh doanh";
                        }
                        else
                        {
                            item.StrStatus = "Không xác định";
                        }
                        item.AvailableQuantity = GetCount(item.Id);
                        if (item.IdImage > 0)
                        {
                            item.ImageMain = image.FirstOrDefault(x => x.Id == item.IdImage).Url;
                        }
                        else
                        {
                            item.ImageMain = "/uploads/noimage.jpg";
                        }
                    }
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int GetCount(int id)
        {
            int getCount = _unitOfWork.Repository<ProductDetailEntity>().Entities.AsNoTracking()
                .Where(x => x.Status > 0 && x.Id == id)
                .Join(_unitOfWork.Repository<SerialEntity>().Entities.AsNoTracking().Where(x => x.BillDetailEntityId == null),
                      a => a.Id,
                      b => b.ProductDetailEntityId,
                      (a, b) => new { a.Id })
                .Count();
            return getCount;
        }
    }
}
