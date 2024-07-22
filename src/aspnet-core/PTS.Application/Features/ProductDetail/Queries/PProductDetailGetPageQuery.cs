﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.DTOs;
using PTS.Application.Extensions;
using PTS.Application.Features.ProductDetail.DTOs;
using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Entities;
using PTS.Shared;

namespace PTS.Application.Features.ProductDetail.Queries
{
    public record PProductDetailGetPageQuery : BaseGetPageQuery, IRequest<PaginatedResult<PProductDetailGetPageDto>>
	{
        public string? Manufacturer { get; set; }
		public string? ProductType { get; set; }
		public int? Ram {  get; set; }
		public string? CPU { get; set; }
		public string? CardVGA { get; set; }
		public string? HardDrive { get; set; }
		public string? Screen { get; set; }
		public string? Search { get; set; }
		public int? Price { get; set; }
		public int? SortBy { get; set; }
	}

	internal class PProductDetailGetPagesQueryHandler : IRequestHandler<PProductDetailGetPageQuery, PaginatedResult<PProductDetailGetPageDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly ISender _sender;

		public PProductDetailGetPagesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ISender sender)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_sender = sender;
		}

		public async Task<PaginatedResult<PProductDetailGetPageDto>> Handle(PProductDetailGetPageQuery queryInput, CancellationToken cancellationToken)
		{
			try
			{
				var image = _unitOfWork.Repository<ImageEntity>().Entities.AsNoTracking();
			    var query = (from a in _unitOfWork.Repository<ProductDetailEntity>().Entities.AsNoTracking()
						join pImage in _unitOfWork.Repository<ProductDetailImage>().Entities.Where(x => x.IsIndex).AsNoTracking()
							 on a.Id equals pImage.ProductDetailId into pImageGroup
						from pImage in pImageGroup.DefaultIfEmpty()
						select new PProductDetailGetPageDto
						{
							Id = a.Id,
							Code = a.Code,
							OldPrice = a.OldPrice,
							Price = a.Price,
							Status = a.Status,
							Upgrade = a.Upgrade,
							Description = a.Description,
							CrDateTime = a.CrDateTime,
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
							PhanTramGiamGia = Convert.ToInt32((((a.OldPrice - a.Price) / a.OldPrice) * 100)),
							IdImage = pImage != null ? pImage.ImageId : 0
						});
                switch (queryInput.Price)
                {
                    case 1:
                        query = query.Where(x => x.Price >= 0 && x.Price <= 10000000);
                        break;
                    case 2:
                        query = query.Where(x => x.Price > 10000000 && x.Price <= 20000000);
                        break;
                    case 3:
                        query = query.Where(x => x.Price > 20000000 && x.Price <= 30000000);
                        break;
                    case 4:
                        query = query.Where(x => x.Price > 30000000 && x.Price <= 40000000);
                        break;
                    case 5:
                        query = query.Where(x => x.Price > 40000000 && x.Price <= 50000000);
                        break;
                    case 6:
                        query = query.Where(x => x.Price > 50000000);
                        break;
                    default:
                        break;
                }

                switch (queryInput.Ram)
                {
                    case 1:
                        query = query.Where(x => x.ThongSoRam.Contains("4GB"));
                        break;
                    case 2:
                        query = query.Where(x => x.ThongSoRam.Contains("8GB"));
                        break;
                    case 3:
                        query = query.Where(x => x.Price > 20000000 && x.Price <= 30000000);
                        break;
                    case 4:
                        query = query.Where(x => x.Price > 30000000 && x.Price <= 40000000);
                        break;
                    case 5:
                        query = query.Where(x => x.Price > 40000000 && x.Price <= 50000000);
                        break;
                    case 6:
                        query = query.Where(x => x.Price > 50000000);
                        break;
                    default:
                        break;
                }
                switch (queryInput.SortBy )
                {
                    case 1:
                        query = query.OrderBy(x => x.Price);
                        break;
                    case 2:
                        query = query.OrderByDescending(x => x.Price);
                        break;
                    case 3:
                        query = query.OrderBy(x => x.CrDateTime);
                        break;
                    case 4:
                        query = query.OrderBy(x => x.NameProduct);
                        break;
                    default:
                        break;
                }

                //if (!string.IsNullOrEmpty(queryInput.ProductType))
                //{
                //	query = query.Where(a => a.ProductEntity.ProductTypeEntity.Name == queryInput.ProductType);
                //}

                //if (!string.IsNullOrEmpty(queryInput.Keywords))
                //{
                //	query = query.Where(a => a.ProductEntity.Name.Contains(queryInput.Keywords) || a.Code.Contains(queryInput.Keywords));
                //}

                //if (!string.IsNullOrEmpty(queryInput.SortBy))
                //{
                //	switch (queryInput.SortBy)
                //	{
                //		case "price_asc":
                //			query = query.OrderBy(x => x.Price);
                //			break;
                //		case "price_desc":
                //			query = query.OrderByDescending(x => x.Price);
                //			break;
                //	}
                //}

                var result = await query.ToPaginatedListAsync(queryInput.Page, queryInput.PageSize, cancellationToken);

			foreach (var productDetail in result.Data)
			{
			     	productDetail.AvailableQuantity = GetCount(productDetail.Id);
					if(productDetail.IdImage > 0)
					{
						productDetail.ImageMain = image.FirstOrDefault(x => x.Id == productDetail.IdImage).Url;
					}
					else
					{
						productDetail.ImageMain = "/uploads/noimage.jpg";
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
				.Join(_unitOfWork.Repository<SerialEntity>().Entities.AsNoTracking(),
					  a => a.Id,
					  b => b.ProductDetailEntityId,
					  (a, b) => new { a.Id })
				.Count();
			return getCount;
		}
	}
}