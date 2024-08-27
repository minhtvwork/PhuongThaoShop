using AutoMapper;
using AutoMapper.QueryableExtensions;
using PTS.Application.DTOs;
using PTS.Application.Extensions;
using MediatR;
using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Entities;
using PTS.Shared;
using PTS.Application.Features.Serial.DTOs;
using PTS.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace PTS.Application.Features.Serial.Queries
{
    public record SerialGetPageQuery : BaseGetPageQuery, IRequest<PaginatedResult<SerialDto>>
    {
     
    }
    internal class SerialGetPagesQueryHandler : IRequestHandler<SerialGetPageQuery, PaginatedResult<SerialDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SerialGetPagesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<SerialDto>> Handle(SerialGetPageQuery queryInput, CancellationToken cancellationToken)
        {
            var query = from serial in _unitOfWork.Repository<SerialEntity>().Entities
                        where serial.Status != (int)StatusEnum.Delete
                        join productDetail in _unitOfWork.Repository<ProductDetailEntity>().Entities
                        on serial.ProductDetailEntityId equals productDetail.Id
                        join billDetail in _unitOfWork.Repository<BillDetailEntity>().Entities
                        on serial.BillDetailEntityId equals billDetail.Id into billDetails
                        from bd in billDetails.DefaultIfEmpty()
                        select new SerialDto
                        {
                            SerialNumber = serial.SerialNumber,
                            CrDateTime = serial.CrDateTime,
                            Status = serial.Status,
                            ProductDetailEntityId = serial.ProductDetailEntityId,
                            BillDetailEntityId = serial.BillDetailEntityId,
                            CodeProductDetail = productDetail.Code,
                            CodeBillDetail = bd != null ? bd.Code : null, 
                        };

            if (!string.IsNullOrEmpty(queryInput.Keywords))
            {
                query = query.Where(x => x.SerialNumber.Contains(queryInput.Keywords));
            }

            query = query.OrderBy(x => x.CrDateTime);
            var result = await query.ToPaginatedListAsync(queryInput.Page, queryInput.PageSize, cancellationToken);

            if (result.Data != null && result.Data.Any())
            {
                int index = (queryInput.Page - 1) * queryInput.PageSize + 1;
                foreach (var item in result.Data)
                {
                    item.Stt = index++;
                }
            }

            return result;
        }


    }
}
