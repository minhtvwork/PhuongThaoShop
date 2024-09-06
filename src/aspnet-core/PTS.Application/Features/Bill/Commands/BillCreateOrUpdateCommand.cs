using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PTS.Application.Common.Mappings;
using PTS.Application.Interfaces.Repositories;
using PTS.Domain.Entities;
using PTS.Shared;
using PTS.Core.Enums;
using PTS.Shared.Utilities;
using Microsoft.AspNetCore.Identity;
using PTS.Application.Features.BillDetail.Queries;
using System.Linq.Dynamic.Core;

namespace PTS.Application.Features.Bill.Commands
{
    public record BillCreateOrUpdateCommand : IRequest<Result<int>>, IMapFrom<BillEntity>
    {
        public int Id { get; set; }
        public string? InvoiceCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public int Payment { get; set; }
        public bool IsPayment { get; set; }
        public decimal? Discount { get; set; }
        public int? VoucherEntityId { get; set; }
        public int? UserEntityId { get; set; }
        public int? CrUserId { get; set; }
        public DateTime? CrDateTime { get; set; }
        public int Status { get; set; }
    }

    internal class BillCreateOrUpdateCommandHandler : IRequestHandler<BillCreateOrUpdateCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;
        private readonly ISender _sender;

        public BillCreateOrUpdateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<UserEntity> userManager, ISender sender)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _sender = sender;
        }

        public async Task<Result<int>> Handle(BillCreateOrUpdateCommand command, CancellationToken cancellationToken)
        {
            try
            {

                var listUser = _userManager.Users.AsNoTracking().ToList();
                if (!IsValidPhoneNumber(command.PhoneNumber))
                {
                    return await Result<int>.FailureAsync($"Số điện thoại {command.PhoneNumber} là số điện thoại không hợp lệ");
                }
                if (command.Id > 0)
                {
                    // Update
                    var existingEntity = await _unitOfWork.Repository<BillEntity>().Entities.AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

                    if (existingEntity == null)
                    {
                        return await Result<int>.FailureAsync($"Id <b>{command.Id}</b> không tồn tại");
                    }
                    BillDetailGetByBillIdQuery query = new BillDetailGetByBillIdQuery() { BillId = command.Id};
                    var billDetail = await _sender.Send(query);
                    if (billDetail.Data != null && command.Status != (int)BillStatusEnum.Cancelled) { 
                        foreach (var item in billDetail.Data)
                        {
                            if (item.ListSerial == null)
                            {
                                return await Result<int>.FailureAsync($"Hóa đơn có mã sản phẩm:{item.CodeProductDetail} chưa có số serial, hãy thêm serial");
                            }
                            if (item.ListSerial.Count < item.Quantity)
                            {
                                return await Result<int>.FailureAsync($"Hóa đơn có mã sản phẩm:{item.CodeProductDetail} chưa đủ số lượng serial, hãy thêm serial");
                            }
                        }
                    }
                    if (existingEntity.IsPayment && !command.IsPayment)
                    {
                        return await Result<int>.FailureAsync($"Hóa đơn đã thanh toán, không được cập nhật trạng thái thanh toán");
                    }
                    if (command.Status == (int)BillStatusEnum.Completed && !command.IsPayment)
                    {
                        return await Result<int>.FailureAsync($"Hóa đơn chưa thanh toán, không thể hoàn thành ");
                    }

                    if (existingEntity.Status == (int)BillStatusEnum.Completed)
                    {
                        return await Result<int>.FailureAsync($"Hóa đơn đã hoàn thành không được sửa ");
                    }
                    if (command.Status < existingEntity.Status)
                    {
                        return await Result<int>.FailureAsync("Không thể cập nhật trạng thái về trạng thái thấp hơn.");
                    }
                    if(command.Status == (int)BillStatusEnum.Cancelled)
                    {
                        var listBillDetail = await _unitOfWork.Repository<BillDetailEntity>()
                        .Entities
                        .Where(x => x.BillEntityId == command.Id)
                        .ToListAsync();

                        foreach (var item in listBillDetail)
                        {
                            var serials = await _unitOfWork.Repository<SerialEntity>()
                                .Entities
                                .Where(x => x.BillDetailEntityId == item.Id)
                                .ToListAsync();

                            foreach (var serial in serials)
                            {
                                serial.BillDetailEntityId = null;
                                await _unitOfWork.Repository<SerialEntity>().UpdateFieldsAsync(serial, x => x.BillDetailEntityId);
                            }
                        }
                        await _unitOfWork.Save(cancellationToken);
                    }

                    existingEntity = _mapper.Map(command, existingEntity);
                    existingEntity.UpdDateTime = DateTime.Now; 
                    existingEntity.UpdUserId = command.CrUserId;
                    await _unitOfWork.Repository<BillEntity>().UpdateFieldsAsync(existingEntity,
                        x => x.FullName,
                        x => x.Address,
                        x => x.PhoneNumber,
                        x => x.UpdDateTime,
                        x => x.UpdUserId,
                        x => x.Payment,
                        x => x.IsPayment,
                        x => x.Status);

                    var updateResult = await _unitOfWork.Save(cancellationToken);

                    return updateResult > 0
                        ? await Result<int>.SuccessAsync(existingEntity.Id, "Cập nhật dữ liệu thành công.")
                        : await Result<int>.FailureAsync("Cập nhật dữ liệu không thành công.");
                }
                else
                {
                    // Create
                    var entity = _mapper.Map<BillEntity>(command);
                    entity.InvoiceCode = StringUtility.RandomString(12);
                    entity.IsPayment = false;
                    entity.Status = 2;
                    entity.CrDateTime = DateTime.Now;
                    await _unitOfWork.Repository<BillEntity>().AddAsync(entity);
                    var result = await _unitOfWork.Save(cancellationToken);
                    return result > 0
                        ? await Result<int>.SuccessAsync(entity.Id, "Thêm dữ liệu thành công.")
                        : await Result<int>.FailureAsync("Thêm dữ liệu không thành công.");
                }
            }
            catch (Exception ex)
            {
                return await Result<int>.FailureAsync($"Thêm hoặc cập nhật dữ liệu không thành công: {ex.Message}");
            }
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
