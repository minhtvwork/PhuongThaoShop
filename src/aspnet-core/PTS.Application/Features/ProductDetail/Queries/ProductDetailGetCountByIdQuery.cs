﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Features.ProductDetail.DTOs;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Enums;
using PTS.Domain.Entities;
using PTS.Shared;

namespace PTS.Application.Features.ProductDetail.Queries
{
	public record PProductDetailGetByIdQuery : IRequest<Result<PProductDetailGetByIdDto>>
	{
		public int Id { get; set; }
	}

	internal class PProductDetailGetByIdQueryHandler : IRequestHandler<PProductDetailGetByIdQuery, Result<PProductDetailGetByIdDto>>
	{
		private readonly IUnitOfWork _unitOfWork;

		public PProductDetailGetByIdQueryHandler(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<Result<PProductDetailGetByIdDto>> Handle(PProductDetailGetByIdQuery queryInput, CancellationToken cancellationToken)
		{
			try
			{
				var imageQuery = _unitOfWork.Repository<ImageEntity>().Entities.AsNoTracking();
				var productQuery = _unitOfWork.Repository<ProductDetailEntity>().Entities
					.Where(x => x.Id == queryInput.Id && x.Status != (int)StatusEnum.Delete)
					.AsNoTracking();

				var query = from a in productQuery
							join pImage in _unitOfWork.Repository<ProductDetailImage>().Entities.Where(x => x.IsIndex).AsNoTracking()
								 on a.Id equals pImage.ProductDetailId into pImageGroup
							from pImage in pImageGroup.DefaultIfEmpty()
							select new PProductDetailGetByIdDto
							{
								Id = a.Id,
								Code = a.Code,
								Price = a.Price,
								Status = a.Status,
								Upgrade = a.Upgrade,
								Description = a.Description,
								AvailableQuantity = 0,
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
								NameManufacturer = a.ProductEntity.ManufacturerEntity.Name,
                                NewPrice = a.Price - (a.Discount != null ? a.Discount.Percentage : 0),
                                PhanTramGiamGia = a.Discount != null && a.Price != 0 ? Convert.ToInt32((a.Discount.Percentage / a.Price) * 100) : 0,
                                IdImage = pImage != null ? pImage.ImageId : 0,
								ListImage = new List<string>()
							};

				var result = await query.SingleOrDefaultAsync(cancellationToken);

				if (result == null)
				{
					return await Result<PProductDetailGetByIdDto>.FailureAsync("Product not found.");
				}

				result.AvailableQuantity = GetCount(result.Id);

                var imageList = await _unitOfWork.Repository<ProductDetailImage>().Entities
                .Where(x => x.ProductDetailId == result.Id)
                .Select(x => x.Image.Url)
                .ToListAsync(cancellationToken);

                if (imageList != null && imageList.Count > 0)
                {
                    result.ListImage.AddRange(imageList);
                }
                else
                {
                    result.ImageMain = "/uploads/noimage.jpg";
                }

                return await Result<PProductDetailGetByIdDto>.SuccessAsync(result);
			}
			catch (Exception ex)
			{
				return await Result<PProductDetailGetByIdDto>.FailureAsync(ex.Message);
			}
		}

		private int GetCount(int id)
		{
			int getCount = _unitOfWork.Repository<ProductDetailEntity>().Entities.AsNoTracking()
				.Where(x => x.Status > 0 && x.Id == id)
				.Join(_unitOfWork.Repository<SerialEntity>().Entities.AsNoTracking().Where(x => x.BillDetailEntityId == null &&  x.Status != (int)StatusEnum.Delete),
					  a => a.Id,
					  b => b.ProductDetailEntityId,
					  (a, b) => new { a.Id })
				.Count();
			return getCount;
		}
	}
}
