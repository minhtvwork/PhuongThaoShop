﻿using PTS.Domain.Dto;

namespace PTS.Host.Service.IService
{
    public interface IBillService
    {
        Task<ResponseDto> CreateBill(RequestBillDto request);
        Task<ResponseDto> PGetBillByInvoiceCode(string invoiceCode);
        Task<ResponseDto> GetBillDetailByInvoiceCode(string invoiceCode);
        // Task<ResponseDto> GetAllBill();
        Task<ResponseDto> GetAllBill(string? phoneNumber);
    }
}
