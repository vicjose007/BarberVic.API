﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BarberVic.Domain.BaseModel.BaseEntityDto;
using BarberVic.Domain.Entities;
using BarberVic.Domain.Enum;

namespace BarberVic.Application.Dtos
{
    public class UserDto : BaseEntityDto
    {

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; }

        public string Phone { get; set; } = string.Empty;
    }
}
