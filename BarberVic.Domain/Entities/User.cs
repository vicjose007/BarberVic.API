using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberVic.Domain.BaseModel.BaseEntity;
using BarberVic.Domain.Enum;

namespace BarberVic.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; }
        public string Phone { get; set; }
        public Roles roles { get; set; }

    }
}
