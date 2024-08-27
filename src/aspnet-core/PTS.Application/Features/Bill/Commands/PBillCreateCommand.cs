using MediatR;
using PTS.Application.Dto;
using PTS.Application.Features.Bill.DTOs;
using PTS.Core.Services;
using PTS.Domain.Entities;
using PTS.Domain.Model.Base;

namespace PTS.Application.Features.Bill.Commands
{
    public class PBillCreateCommand : IRequest<ApiResult<BillDto>>
    {
        public string? PhoneNumber { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? UserName { get; set; }
        public string? CodeVoucher { get; set; }
        public string? Notes { get; set; }
        public int Payment { get; set; }
        public List<CartItemDto>? CartItem { get; set; }
    }

    public class PBillCreateCommandHandler : IRequestHandler<PBillCreateCommand, ApiResult<BillDto>>
    {
        private readonly IBillService _service;

        public PBillCreateCommandHandler(IBillService service)
        {
            _service = service;
        }

        public async Task<ApiResult<BillDto>> Handle(PBillCreateCommand command, CancellationToken cancellationToken)
        {
            if (!IsValidPhoneNumber(command.PhoneNumber) && command.UserName == null)
            {
                return new ApiResult<BillDto>
                {
                    IsSuccessed = false,
                    Message = "Số điện thoại không hợp lệ."
                };
            }
            return await _service.CreateBill(command);
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
                return false;
            var regex = new System.Text.RegularExpressions.Regex(@"^(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b");
            return regex.IsMatch(phoneNumber);
        }
    }
}
