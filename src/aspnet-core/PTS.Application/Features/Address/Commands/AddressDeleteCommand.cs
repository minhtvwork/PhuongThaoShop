﻿using AutoMapper;
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

namespace PTS.Application.Features.Address.Commands
{
	public record AddressDeleteCommand : IRequest<Result<int>>, IMapFrom<AddressEntity>
	{
		public int Id { get; set; }
	}

	internal class AddressDeleteCommandHandler : IRequestHandler<AddressDeleteCommand, Result<int>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public AddressDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<Result<int>> Handle(AddressDeleteCommand command, CancellationToken cancellationToken)
		{
			try
			{
				var entity = await _unitOfWork.Repository<AddressEntity>().GetByIdAsync(command.Id);
				if (entity == null)
				{
					return await Result<int>.FailureAsync($"Id <b>{command.Id}</b> không tồn tại ");
				}
                await _unitOfWork.Repository<AddressEntity>().DeleteAsync(entity);

                var deleteResult = await _unitOfWork.Save(cancellationToken);
                if (deleteResult > 0)
                {
                    return await Result<int>.SuccessAsync($"Xóa dữ liệu thành công ");
                }

                return await Result<int>.FailureAsync($"Xóa dữ liệu không thành công ");
            }
			catch (Exception e)
			{
				throw;
			}
		}
	}
}
