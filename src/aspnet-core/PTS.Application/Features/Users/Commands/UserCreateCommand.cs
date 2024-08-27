using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PTS.Application.DTOs;
using PTS.Shared;
using PTS.Application.Common.Mappings;
using PTS.Domain.Entities;

namespace PTS.Application.Features.IdentityFeatures.Users.Commands
{
    public record UserCreateCommand : BaseCreateCommand, IRequest<Result<int>>, IMapFrom<UserEntity>
    {
        [DisplayName("Tên truy cập")]
        public string UserName { get; set; }

        public string Email { get; set; }

        [DisplayName("Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Mật khẩu xác nhận")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }
        [DisplayName("Họ và tên")]
        public string FullName { get; set; }

        [DisplayName("Ghi chú")]
        public string Notes { get; set; }
        [DisplayName("Kích hoạt")]
        public bool IsEnabled { get; set; }
    }

    internal class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, Result<int>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;
		private readonly IMediator _mediator;

		public UserCreateCommandHandler(IMapper mapper,UserManager<UserEntity> userManager, 
            IMediator mediator)
        {
            _mapper = mapper;
            _userManager = userManager;
            _mediator = mediator;
        }

        public async Task<Result<int>> Handle(UserCreateCommand command, CancellationToken cancellationToken)
        {
            UserEntity entity = _mapper.Map<UserEntity>(command);

            entity.NormalizedEmail = entity.Email;
            entity.NormalizedUserName = entity.UserName;
            entity.SecurityStamp = entity.UserName;
            entity.ConcurrencyStamp = entity.UserName;

            PasswordHasher<UserEntity> passwordHasher = new PasswordHasher<UserEntity>();
            entity.PasswordHash = passwordHasher.HashPassword(entity, command.Password);

			IdentityResult identityResult = await _userManager.CreateAsync(entity);

            if (!identityResult.Succeeded)
            {
                return await Result<int>.FailureAsync(string.Join(", ", identityResult.Errors.Select(x => x.Description)));
            }

			return await Result<int>.SuccessAsync(entity.Id, "Thêm dữ liệu thành công.");
        }
    }
}
