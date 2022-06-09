using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberVic.Domain.BaseModel.BaseEntityDto;
using BarberVic.Domain.Enum;

namespace BarberVic.Application.Dtos
{
    public class UserDto : BaseEntityDto
    {
        public string NameDto { get; set; } = string.Empty;
        public string LastNameDto { get; set; } = string.Empty;
        public string EmailDto { get; set; } = string.Empty;
        public string PasswordDto { get; set; }
        public string PhoneDto { get; set; }
        public Roles rolesDto { get; set; }
    }
}
