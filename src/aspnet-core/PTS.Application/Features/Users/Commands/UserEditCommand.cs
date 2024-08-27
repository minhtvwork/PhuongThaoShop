
using MediatR;
using Microsoft.AspNetCore.Identity;
using PTS.Application.Common.Mappings;
using PTS.Application.DTOs;
using PTS.Application.Features.Bill.DTOs;
using PTS.Application.Features.IdentityFeatures.Users.Queries;
using PTS.Domain.Entities;
using PTS.Domain.Model.Base;
using PTS.Shared;
using System.ComponentModel;

namespace PTS.Application.Features.IdentityFeatures.Users.Commands
{
    public record UserEditCommand : BaseEditCommand, IRequest<Result<int>>, IMapFrom<UserGetByIdDto>
    {
        public int Id { get; set; }
        [DisplayName("Tên truy cập")]
        public string? UserName { get; set; }

        public string Email { get; set; }

        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }

        [DisplayName("Họ và tên")]
        public string FullName { get; set; }


    }

    internal class UserEditCommandHandler : IRequestHandler<UserEditCommand, Result<int>>
    {
        private readonly UserManager<UserEntity> _userManager;

        public UserEditCommandHandler(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<int>> Handle(UserEditCommand command, CancellationToken cancellationToken)
        {
            var entity = await _userManager.FindByIdAsync(command.Id.ToString());

            if (entity == null)
            {
                return await Result<int>.FailureAsync($"Tài khoản Id <b>{command.Id}</b> không tồn tại.");
            }
            if (!IsValidPhoneNumber(command.PhoneNumber) && command.UserName == null)
            {
                return await Result<int>.FailureAsync($"Số điện thoại không đúng định dạng.");
            }
            entity.FullName = command.FullName;
            entity.Email = command.Email;
            entity.PhoneNumber = command.PhoneNumber;
            entity.NormalizedEmail = entity.Email;

            IdentityResult identityResult = await _userManager.UpdateAsync(entity);

            if (!identityResult.Succeeded)
            {
                return await Result<int>.FailureAsync(string.Join(", ", identityResult.Errors.Select(x => x.Description)));
            }


			return await Result<int>.SuccessAsync(entity.Id, $"Cập nhật tài khoản <b>{entity.UserName}</b> thành công.");
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
