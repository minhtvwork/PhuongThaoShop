using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Features.BillDetail.DTOs;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Enums;
using PTS.Domain.Entities;
using PTS.Shared;

namespace PTS.Application.Features.BillDetail.Queries
{
    public record BillDetailGetByBillIdQuery : IRequest<Result<List<BillDetailDto>>>
    {
        public int BillId { get; set; } 
    }
    internal class BillDetailGetByBillIdQueryHandler : IRequestHandler<BillDetailGetByBillIdQuery, Result<List<BillDetailDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BillDetailGetByBillIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<BillDetailDto>>> Handle(BillDetailGetByBillIdQuery queryInput, CancellationToken cancellationToken)
        {
            // Lấy danh sách SerialEntity từ cơ sở dữ liệu
            var listSerial = await _unitOfWork.Repository<SerialEntity>().Entities
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            // Lấy danh sách BillDetailDto tương ứng với BillId
            var result = await _unitOfWork.Repository<BillDetailEntity>().Entities
                .AsNoTracking()
                .Where(x => x.BillEntityId == queryInput.BillId)
                .ProjectTo<BillDetailDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            if (result != null && result.Any())
            {
                foreach (var item in result)
                {
                    // Khởi tạo ListSerial nếu nó chưa được khởi tạo
                    item.ListSerial ??= new List<string>();

                    // Lấy các serial tương ứng với BillDetailEntityId và thêm vào ListSerial
                    var serialNumbers = listSerial
                        .Where(x => x.BillDetailEntityId == item.Id)
                        .Select(x => x.SerialNumber);

                    if (serialNumbers.Any())
                    {
                        item.ListSerial.AddRange(serialNumbers);
                    }
                }
            }

            return await Result<List<BillDetailDto>>.SuccessAsync(result);
        }
    }

}
