﻿using AutoMapper;
using MediatR;
using PTS.Application.Common.Mappings;
using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Entities;
using PTS.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PTS.Application.Features.Voucher.Commands
{
    public record VoucherEditCommand : IRequest<Result<int>>, IMapFrom<VoucherEntity>
    {
		public int Id { get; set; }
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

    internal class VoucherEditCommandHandler : IRequestHandler<VoucherEditCommand, Result<int>>
    {
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public VoucherEditCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<Result<int>> Handle(VoucherEditCommand command, CancellationToken cancellationToken)
        {
			try
			{
				var entity = await _unitOfWork.Repository<VoucherEntity>().GetByIdAsync(command.Id);
				if (entity == null)
				{
					return await Result<int>.FailureAsync($"Id <b>{command.Id}</b> không tồn tại ");
				}
				entity = _mapper.Map<VoucherEntity>(command);
				await _unitOfWork.Repository<VoucherEntity>().UpdateFieldsAsync(entity,
					x => x.TenVoucher,
					x => x.StartDay,
					x => x.EndDay,
					x => x.GiaTri,
					x => x.SoLuong,
					x => x.Status);
				var result = await _unitOfWork.Save(cancellationToken);
				return result > 0
						? await Result<int>.SuccessAsync(entity.Id, "Cập nhật dữ liệu thành công.")
						: await Result<int>.FailureAsync("Cập nhật dữ liệu không thành công.");
			}
			catch (Exception e)
			{

				throw;
			}
		}
    }
}
