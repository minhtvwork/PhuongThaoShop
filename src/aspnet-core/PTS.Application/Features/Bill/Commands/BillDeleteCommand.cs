using AutoMapper;
using MediatR;
using PTS.Application.Common.Mappings;
using PTS.Core.Enums;
using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Entities;
using PTS.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PTS.Application.Features.Bill.Commands
{
	public record BillDeleteCommand : IRequest<Result<int>>, IMapFrom<BillEntity>
	{
		public int Id { get; set; }
	}

	internal class BillDeleteCommandHandler : IRequestHandler<BillDeleteCommand, Result<int>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public BillDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<Result<int>> Handle(BillDeleteCommand command, CancellationToken cancellationToken)
		{
			try
			{
				var entity = await _unitOfWork.Repository<BillEntity>().GetByIdAsync(command.Id);
				if (entity == null)
				{
					return await Result<int>.FailureAsync($"Id <b>{command.Id}</b> không tồn tại ");
				}
                if (entity.Status != (int)BillStatusEnum.Cancelled)
                {
                    return await Result<int>.FailureAsync($"Bạn chỉ được phép xóa những đơn hàng đã hủy");
                }
                var listBillDetail = await _unitOfWork.Repository<BillDetailEntity>()
                      .Entities
                      .Where(x => x.BillEntityId == command.Id)
                      .ToListAsync();
				foreach (var item in listBillDetail)
				{
                    await _unitOfWork.Repository<BillDetailEntity>().DeleteAsync(item);
                }
				await _unitOfWork.Repository<BillEntity>().DeleteAsync(entity);

                var deleteResult = await _unitOfWork.Save(cancellationToken);
                if (deleteResult > 0)
                {
                    return await Result<int>.SuccessAsync($"Xóa dữ liệu thành công ");
                }

                return await Result<int>.FailureAsync($"Xóa dữ liệu không thành công ");
                //            entity = _mapper.Map<BillEntity>(command);
                //entity.Status = (int)StatusEnum.Delete;
                //await _unitOfWork.Repository<BillEntity>().UpdateFieldsAsync(entity,
                //	x => x.Status);
                //var result = await _unitOfWork.Save(cancellationToken);
                //return result > 0
                //		? await Result<int>.SuccessAsync(entity.Id, "Cập nhật dữ liệu thành công.")
                //		: await Result<int>.FailureAsync("Cập nhật dữ liệu không thành công.");
            }
			catch (Exception e)
			{
				throw;
			}
		}
	}
}
