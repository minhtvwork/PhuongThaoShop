﻿using PTS.Domain.Entities;

namespace PTS.Domain.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Provider { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public bool isAdmin { get; set; }

    }
}
