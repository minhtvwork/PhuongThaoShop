using AutoMapper;
using AutoMapper.QueryableExtensions;
using PTS.Application.DTOs;
using PTS.Application.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Entities;
using PTS.Shared;
using PTS.Application.Features.Bill.DTOs;
using PTS.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace PTS.Application.Features.Bill.Queries
{
    public record BillGetPageV2Query : BaseGetPageQuery, IRequest<PaginatedResult2<BillGetPageDto>>
    {
        public int Type { get; set; }
        public int Status { get; set; }
    }
    internal class BillGetPagesV2QueryHandler : IRequestHandler<BillGetPageV2Query, PaginatedResult2<BillGetPageDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;
        public BillGetPagesV2QueryHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<UserEntity> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<PaginatedResult2<BillGetPageDto>> Handle(BillGetPageV2Query queryInput, CancellationToken cancellationToken)
        {
            var listUser = _userManager.Users.AsNoTracking().ToList();
            var query = from listObj in _unitOfWork.Repository<BillEntity>().Entities.Where(x => x.Status != (int)StatusEnum.Delete && x.Status != 7 && x.Status !=8).AsNoTracking() select listObj;
            var query2 = from listObj in _unitOfWork.Repository<BillEntity>().Entities.Where(x => x.Status != (int)StatusEnum.Delete && x.Status != 7 && x.Status != 8).AsNoTracking() select listObj;

            if (queryInput.Type == 1)// 
            {
                query = query.Where(x => x.CrUserId == null);
                query2 = query2.Where(x => x.CrUserId == null);

            }
            else if (queryInput.Type == 2)// 
            {
                query = query.Where(x => x.CrUserId > 0);
                query2 = query2.Where(x => x.CrUserId > 0);
            }
            if (!string.IsNullOrEmpty(queryInput.Keywords))
            {
                var lowerKeywords = queryInput.Keywords.ToLower();
                query = query.Where(x => x.PhoneNumber.ToLower().Contains(lowerKeywords) ||
                                         x.FullName.ToLower().Contains(lowerKeywords) ||
                                         x.InvoiceCode.ToLower().Contains(lowerKeywords));
            }
            if (queryInput.Status > 0)
            {
                query = query.Where(x => x.Status == queryInput.Status);
            }
            query = query.OrderByDescending(x => x.CrDateTime);
            var pQuery = query.ProjectTo<BillGetPageDto>(_mapper.ConfigurationProvider);
            var resultVar = await pQuery.ToPaginated2ListAsync(queryInput.Page, queryInput.PageSize, cancellationToken);
            resultVar.TotalStatus = query2.Count();
            resultVar.TotalStatus2 = query2.Count(x => x.Status == 2);
            resultVar.TotalStatus3 = query2.Count(x => x.Status == 3);
            resultVar.TotalStatus4 = query2.Count(x => x.Status == 4);
            resultVar.TotalStatus5 = query2.Count(x => x.Status == 5);
            resultVar.TotalStatus6 = query2.Count(x => x.Status == 6);
            resultVar.TotalStatus7 = query2.Count(x => x.Status == 7);
            resultVar.TotalStatus8 = query2.Count(x => x.Status == 8);
            if (resultVar.Data != null && resultVar.Data.Any())
            {
                int index = (queryInput.Page - 1) * queryInput.PageSize + 1;
                foreach (var item in resultVar.Data)
                {
                    item.StrPayment = GetStringPayment(item.Payment);
                    item.Stt = index++;
                    item.StrStatus = GetStringStatus(item.Status);
                    item.StrIsPayment = item.IsPayment ? "Đã thanh toán" : "Chưa thanh toán";
                    if (item.CrUserId.HasValue)
                    {
                        item.CrUserName = listUser.FirstOrDefault(x => x.Id == item.CrUserId).UserName;
                    }
                    else
                    {
                        item.CrUserName = "---";
                    }
                    if (item.UpdUserId.HasValue)
                    {
                        item.UpdUserName = listUser.FirstOrDefault(x => x.Id == item.UpdUserId).UserName;
                    }
                    else
                    {
                        item.UpdUserName = "---";
                    }
                }
            }
            return resultVar;
        }
        private string GetStringPayment(int payment)
        {
            return payment switch
            {
                1 => "Thanh toán tại cửa hàng",
                2 => "Thanh toán khi nhận hàng (COD)",
                3 => "Thanh toán bằng chuyển khoản ngân hàng",
                4 => "Thanh toán qua VNPAY",
                _ => "Không xác định"
            };
        }
        private string GetStringStatus(int status)
        {
            return status switch
            {
                0 => "Đã xóa",
                2 => "Chờ xác nhận",
                3 => "Chờ gửi hàng",
                4 => "Đang giao hàng",
                5 => "Giao hàng thành công",
                6 => "Giao hàng thất bại",
                7 => "Đã hủy",
                8 => "Hoàn thành",
                _ => "Không xác định"
            };
        }
    }
}
