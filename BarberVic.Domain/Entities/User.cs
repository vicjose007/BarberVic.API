using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BarberVic.Domain.BaseModel.BaseEntity;
using BarberVic.Domain.Enum;

namespace BarberVic.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public string LastName { get; set; } = string.Empty;
        [JsonIgnore]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; }
        [JsonIgnore]
        public string Phone { get; set; } = string.Empty;
        [JsonIgnore]
        public Roles roles { get; set; }
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }


    }
}
