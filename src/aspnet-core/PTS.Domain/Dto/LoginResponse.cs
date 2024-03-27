﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS.Domain.Dto
{
    public record LoginResponse(bool IsSuccess,bool IsAdmin, string? AccessToken, object? Result)
    {
    }
}
