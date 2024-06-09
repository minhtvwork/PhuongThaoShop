using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Common.Mappings;
using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Entities;
using PTS.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PTS.Application.Features.Voucher.Commands
{
    public record VoucherCreateCommand : IRequest<Result<int>>, IMapFrom<VoucherEntity>
    {
		[MaxLength(50)]
		public string MaVoucher { get; set; }
		[MaxLength(200)]
		public string? TenVoucher { get; set; }
		public DateTime? StartDay { get; set; }
		public DateTime? EndDay { get; set; }
		public decimal GiaTri { get; set; }
		public int SoLuong { get; set; }
		public int Status { get; set; }
	}

    internal class VoucherCreateCommandHandler : IRequestHandler<VoucherCreateCommand, Result<int>>
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public VoucherCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<Result<int>> Handle(VoucherCreateCommand command, CancellationToken cancellationToken)
        {
            try
            {
				bool isAny =await _unitOfWork.Repository<VoucherEntity>().Entities.AnyAsync(a=> a.MaVoucher == command.MaVoucher);
				if(!isAny)
				{
                var entity = _mapper.Map<VoucherEntity>(command);
                entity.CrDateTime = DateTime.Now;
                await _unitOfWork.Repository<VoucherEntity>().AddAsync(entity); 
                var result = await _unitOfWork.Save(cancellationToken);
                return result > 0
                    ? await Result<int>.SuccessAsync(entity.Id, "Thêm dữ liệu thành công.")
                    : await Result<int>.FailureAsync("Thêm dữ liệu không thành công.");
				}
				else
				{
					return await Result<int>.FailureAsync($"Thêm dữ liệu không thành công: Mã đã tồn tại");
				}
			
            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync($"Thêm dữ liệu không thành công: {ex.Message}");
            }
        }
    }
}
