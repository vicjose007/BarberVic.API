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

        public DateTime Date { get; set; }

        //Relacion de Uno a Mucho

        public User User { get; set; }

        public int UserId { get; set; }


        //Relacion de Uno a Mucho

        public Barber Barber { get; set; }

        public int BarberId { get; set; }

        public string BarberName { get; set; }

        //Relacion de Uno a Mucho

        public Haircut Haircut { get; set; }

        public int HaircutId { get; set; }


    }
}
