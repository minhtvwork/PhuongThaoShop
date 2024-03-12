﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PTS.Data;
using PTS.Domain.Dto;
using PTS.Domain.Entities;
using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.Host.Service.IService;

namespace PTS.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        private readonly IBillRepository _billRepository;
        private readonly IConfiguration _config;
        private readonly ApplicationDbContext _context;
        public BillController(IConfiguration config,
            IBillService billService, IBillRepository billRepository, ApplicationDbContext context)
        {
            _config = config;
            _billService = billService;
            _billRepository = billRepository;
            _context = context;
        }
        [AllowAnonymous]
        [HttpGet("PGetBillByInvoiceCode")]
        public async Task<IActionResult> PGetBillByInvoiceCode(string invoiceCode)
        {

            //string? apiKey = _config.GetSection("ApiKey").Value;
            //if (apiKey == null)
            //{
            //    return Unauthorized();
            //}

            //var keyDomain = Request.Headers["Key-Domain"].FirstOrDefault();
            //if (keyDomain != apiKey.ToLower())
            //{
            //    return Unauthorized();
            //}
            var result = await _billService.PGetBillByInvoiceCode(invoiceCode);
           // Log.Information("GetBill => {@_reponse}", result);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
            // }

        }
        [AllowAnonymous]
        [HttpGet("GetListBill")]
        public async Task<IActionResult> GetListBill(string? phoneNumber)
        {
            return Ok(await _billService.GetAllBill(phoneNumber));
        }
        [AllowAnonymous]
        [HttpGet("GetBillDetailByInvoiceCode")]
        public async Task<IActionResult> GetBillDetail(string invoiceCode)
        {
            return Ok(await _billService.GetBillDetailByInvoiceCode(invoiceCode));
        }
        [AllowAnonymous]
        [HttpPost("CreateBill")]
        public async Task<IActionResult> CreateBill(RequestBillDto request)
        {
            var reponse = await _billService.CreateBill(request);
            if (reponse.IsSuccess)
            {
                return Ok(reponse.Message);
            }
            return BadRequest("");
        }
        [AllowAnonymous]
        [HttpPut("UpdateBill")]
        public async Task<IActionResult> UpdateBill(BillEntity bill)
        {
            if (await _billRepository.Update(bill))
            {
                return Ok($"Cập nhật hóa đơn {bill.InvoiceCode} thành công");
            }
            return BadRequest("Cập nhật thất bại");
        }
        //[AllowAnonymous]
        //[HttpGet("GetRevenueStatistics")]
        //public IActionResult GetRevenueStatistics()
        //{
        //    var revenueData = _context.BillDetails
        //        .GroupBy(bd => new { Year = bd.Bill.CreateDate.Year, Month = bd.Bill.CreateDate.Month })
        //        .Select(g => new RevenueDto
        //        {
        //            Date = new DateTime(g.Key.Year, g.Key.Month, 1),
        //            Amount = (decimal)g.Sum(bd => bd.Quantity * bd.Price)
        //        })
        //        .ToList();

        //    return Ok(revenueData);
        //}

        //[AllowAnonymous]
        //[HttpGet("GetRevenueStatistics")]
        //public IActionResult GetRevenueStatistics(int year)
        //{
        //    var revenueData = _context.BillDetailEntity
        //        .Where(bd => bd.BillEntity.Year == year)
        //        .GroupBy(bd => new { Month = bd.Bill.CreateDate.Month })
        //        .Select(g => new RevenueDto
        //        {
        //            Date = new DateTime(year, g.Key.Month, 1),
        //            Amount = (decimal)g.Sum(bd => bd.Quantity * bd.Price)
        //        })
        //        .ToList();

        //    return Ok(revenueData);
        //}


        //[AllowAnonymous]
        //[HttpGet("GetRevenueStatisticss")]
        //public IActionResult GetRevenueStatisticss(DateTime selectedDate)
        //{
        //    var startDate = selectedDate.Date;
        //    var endDate = startDate.AddMonths(1).AddDays(-1);

        //    var dailyStatistics = _context.Bills
        //        .Where(b => b.CreateDate >= startDate && b.CreateDate <= endDate)
        //        .Join(
        //            _context.BillDetailEntis,
        //            bill => bill.Id,
        //            billDetail => billDetail.BillId,
        //            (bill, billDetail) => new
        //            {
        //                Day = bill.CreateDate.Day,
        //                Amount = billDetail.Price * billDetail.Quantity,
        //                // Add other fields as needed
        //            }
        //        )
        //        .GroupBy(result => result.Day)
        //        .Select(group => new
        //        {
        //            Day = group.Key,
        //            Amount = group.Sum(result => result.Amount),
        //            TotalOrders = group.Count(),
        //            // Add other fields as needed
        //        })
        //        .ToList();
        //    return Ok(dailyStatistics);
        //}

    }
}
