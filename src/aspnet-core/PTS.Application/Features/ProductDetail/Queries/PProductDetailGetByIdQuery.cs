using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Features.ProductDetail.DTOs;
using PTS.Application.Interfaces.Repositories;
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
		private readonly IMapper _mapper;
		private readonly ISender _sender;

		public PProductDetailGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ISender sender)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_sender = sender;
		}

		public async Task<Result<PProductDetailGetByIdDto>> Handle(PProductDetailGetByIdQuery queryInput, CancellationToken cancellationToken)
		{
			try
			{
				var image = _unitOfWork.Repository<ImageEntity>().Entities.AsNoTracking();
			    var query = (from a in _unitOfWork.Repository<ProductDetailEntity>().Entities.Where(x => x.Id == queryInput.Id).AsNoTracking()
						join pImage in _unitOfWork.Repository<ProductDetailImage>().Entities.Where(x => x.IsIndex).AsNoTracking()
							 on a.Id equals pImage.ProductDetailId into pImageGroup
						from pImage in pImageGroup.DefaultIfEmpty()
						select new PProductDetailGetByIdDto
						{
							Id = a.Id,
							Code = a.Code,
							OldPrice = a.OldPrice,
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
							PhanTramGiamGia = Convert.ToInt32((((a.OldPrice - a.Price) / a.OldPrice) * 100)),
							IdImage = pImage != null ? pImage.ImageId : 0
						});

				//foreach (var productDetail in result.Data)
				//{
				//     	productDetail.AvailableQuantity = GetCount(productDetail.Id);
				//		if(productDetail.IdImage > 0)
				//		{
				//			productDetail.ImageMain = image.FirstOrDefault(x => x.Id == productDetail.IdImage).Url;
				//		}
				//		else
				//		{
				//			productDetail.ImageMain = "/uploads/noimage.jpg";
				//		}
				//}
				var result = await query.SingleOrDefaultAsync(cancellationToken);
				return await Result<PProductDetailGetByIdDto>.SuccessAsync(result);
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
