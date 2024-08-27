﻿
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PTS.Domain.Entities;
using PTS.Shared;

namespace PTS.Application.Features.IdentityFeatures.Users.Commands
{
	public record UserResetPasswordCommand : IRequest<Result<int>>
	{
		public int Id { get; set; }

		[DisplayName("Mật khẩu")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DisplayName("Mật khẩu xác nhận")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}

	internal class UserResetPasswordHandler : IRequestHandler<UserResetPasswordCommand, Result<int>>
	{
		private readonly UserManager<UserEntity> _userManager;

		public UserResetPasswordHandler(UserManager<UserEntity> userManager)
		{
			_userManager = userManager;
		}

		public async Task<Result<int>> Handle(UserResetPasswordCommand command, CancellationToken cancellationToken)
		{
			var entity = await _userManager.FindByIdAsync(command.Id.ToString());

			if (entity == null)
			{
				return await Result<int>.FailureAsync($"Tài khoản Id {command.Id} không tồn tại.");
			}

			PasswordHasher<UserEntity> passwordHasher = new PasswordHasher<UserEntity>();
			entity.PasswordHash = passwordHasher.HashPassword(entity, command.Password);
			entity.LastTimeChangePass = DateTime.Now;

			IdentityResult identityResult = await _userManager.UpdateAsync(entity);

			if (!identityResult.Succeeded)
			{
				return await Result<int>.FailureAsync(string.Join(", ", identityResult.Errors.Select(x => x.Description)));
			}

			return await Result<int>.SuccessAsync(entity.Id, $"Đặt lại mật khẩu tài khoản <b>{entity.UserName}</b> thành công.");
		}
	}
}
