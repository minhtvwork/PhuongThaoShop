﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Features.Bill.Commands;
using PTS.Application.Features.Bill.Queries;
using PTS.Application.Helper;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Enums;
using PTS.Core.Services;
using PTS.Domain.Entities;
using PTS.Domain.Model.Base;
using PTS.Shared;
using System.Linq;

namespace PTS.Application.Features.Bill.Queries
{
	public record PBillGetByCodeQuery : IRequest<ApiResult<PBillGetByCodeQueryDto>>
	{
		public string InvoiceCode { get; set; }
	}
    public class PBillGetByCodeQueryHandler : IRequestHandler<PBillGetByCodeQuery, ApiResult<PBillGetByCodeQueryDto>>
    {
        private readonly IBillService _service;
        private readonly IBillRepository _billRepository;
        private readonly IBillDetailRepository _billDetailRepository;

        public PBillGetByCodeQueryHandler(IBillService service, IBillRepository billRepository, IBillDetailRepository billDetailRepository)
        {
            _service = service;
            _billRepository = billRepository;
            _billDetailRepository = billDetailRepository;   
        }

        public async Task<ApiResult<PBillGetByCodeQueryDto>> Handle(PBillGetByCodeQuery queryInput, CancellationToken cancellationToken)
        {
            var bill = await _billRepository.GetBillByInvoiceCode(queryInput.InvoiceCode);
            if (bill != null)
            {
                var billDetail = await _billRepository.GetBillDetailByInvoiceCode(queryInput.InvoiceCode);

                var result = new PBillGetByCodeQueryDto
                {
                    InvoiceCode = bill.InvoiceCode,
                    PhoneNumber = bill.PhoneNumber,
                    FullName = bill.FullName,
                    Address = bill.Address,
                    Status = bill.Status,
                    CreateDate = bill.CreateDate,
                    CodeVoucher = bill.CodeVoucher,
                    GiamGia = bill.GiamGia,
                    PaymentStatus = bill.IsPayment ? "Đã thanh toán" : "Chưa thanh toán",
                    Payment = AppUtils.GetPayment(bill.Payment),
                    IsPayment = bill.IsPayment,
                    UserId = bill.UserId,
                    BillDetail = billDetail,
                    Count = billDetail.Count()
                };

                return new ApiResult<PBillGetByCodeQueryDto>
                {
                    IsSuccessed = true,
                    Message = $"Lấy hóa đơn của khách hàng {queryInput.InvoiceCode} thành công.",
                    ResultObj = result
                };
            }

            return new ApiResult<PBillGetByCodeQueryDto>
            {
                IsSuccessed = false,
                Message = $"Không tìm thấy hóa đơn của khách hàng {queryInput.InvoiceCode}."
            };
        }
    }
}
