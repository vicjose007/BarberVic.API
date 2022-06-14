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

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; }
 
        public string Phone { get; set; } = string.Empty;

        public Roles roles { get; set; }
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }

        //Relacion Uno a Muchos

        public List<Appointment> Appointments { get; set; } 


    }
}
