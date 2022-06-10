using System;
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

        public string? Name { get; set; }

        public string? Password { get; set; }
    }
}
