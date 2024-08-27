using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Common.Mappings;
using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Entities;
using PTS.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace PTS.Application.Features.Manufacturer.Commands
{
    public record ManufacturerCreateOrUpdateCommand : IRequest<Result<int>>, IMapFrom<ManufacturerEntity>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CrUserId { get; set; }
        public DateTime? CrDateTime { get; set; }
        public int Status { get; set; }
    }
    internal class ManufacturerCreateOrUpdateCommandHandler : IRequestHandler<ManufacturerCreateOrUpdateCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ManufacturerCreateOrUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(ManufacturerCreateOrUpdateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                command.Status = 1;
                if (command.Id > 0)
                {
                    // Update logic
                    var entity = await _unitOfWork.Repository<ManufacturerEntity>().GetByIdAsync(command.Id);
                    if (entity == null)
                    {
                        return await Result<int>.FailureAsync($"Id <b>{command.Id}</b> không tồn tại ");
                    }
                    if (command.Name != entity.Name)
                    {
                        var existing = await _unitOfWork.Repository<ManufacturerEntity>().Entities.AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Name == command.Name, cancellationToken);
                        if (existing != null)
                        {
                            return await Result<int>.FailureAsync("Tên đã tồn tại. Vui lòng chọn tên khác.");
                        }
                    }
                    entity = _mapper.Map(command, entity);
                    await _unitOfWork.Repository<ManufacturerEntity>().UpdateAsync(entity.Id, entity);
                }
                else
                {
                    // Create logic
                    var existing = await _unitOfWork.Repository<ManufacturerEntity>().Entities.AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Name == command.Name, cancellationToken);
                    if (existing != null)
                    {
                        return await Result<int>.FailureAsync("Tên đã tồn tại. Vui lòng chọn mã khác.");
                    }
                    var entity = _mapper.Map<ManufacturerEntity>(command);
                    entity.CrDateTime = DateTime.Now;
                    await _unitOfWork.Repository<ManufacturerEntity>().AddAsync(entity);
                }

                var result = await _unitOfWork.Save(cancellationToken);
                return result > 0
                    ? await Result<int>.SuccessAsync(command.Id > 0 ? command.Id : command.Id, command.Id > 0 ? "Cập nhật dữ liệu thành công." : "Thêm dữ liệu thành công.")
                    : await Result<int>.FailureAsync(command.Id > 0 ? "Cập nhật dữ liệu không thành công." : "Thêm dữ liệu không thành công.");
            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync($"Xử lý không thành công: {ex.Message}");
            }
        }
    }
}
