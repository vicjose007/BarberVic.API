using BarberVic.Domain.BaseModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BarberVic.Domain.Entities
{
    public class Appointment : BaseEntity
    {

        public string Barber { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        //Relacion de Uno a Mucho
        [JsonIgnore]
        public User User { get; set; }

        public int UserId { get; set; }


    }
}
