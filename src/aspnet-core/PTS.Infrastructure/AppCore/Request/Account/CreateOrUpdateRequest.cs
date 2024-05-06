﻿using MediatR;
using PTS.Core.Dto;
using PTS.Core.Entities;
using PTS.Core.Repositories;

namespace PTS.Host.AppCore.Request.Account
{
    public class CreateOrUpdateAccountQuery : IRequest<ServiceResponse>
    {
        public UserDto? UserDto { get; set; }
    }
    public class CreateOrUpdateAccountHandler : IRequestHandler<CreateOrUpdateAccountQuery, ServiceResponse>
    {
        private readonly IUserRepository _repository;
        public CreateOrUpdateAccountHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<ServiceResponse> Handle(CreateOrUpdateAccountQuery request, CancellationToken cancellationToken)
        {
            UserEntity user = new UserEntity();
            user.Id = request.UserDto.Id;
            user.Username = request.UserDto.Username;
            user.PhoneNumber = request.UserDto.PhoneNumber;
            user.FullName = request.UserDto.FullName;
            user.Email = request.UserDto.Email;
            user.Address = request.UserDto.Address;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.UserDto.Password);
            user.CreationTime = DateTime.Now;
            user.IsDeleted = false;
            user.Status = 1;
            if (request.UserDto.Id > 0)
            {
                if (await _repository.Update(user))
                {
                    return new ServiceResponse(true, "Cập nhật thành công");

                }
                return new ServiceResponse(false, "Cập nhật hất bại");
            }
            else
            {
                user.RoleEntityId = 2;
                if (await _repository.Create(user))
                      return new ServiceResponse(true, "Thêm thành công");
                return new ServiceResponse(false, "Thêm thất bại");
            }


        }
    }
}
