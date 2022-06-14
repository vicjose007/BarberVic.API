using BarberVic.Domain.BaseModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Domain.Entities
{
    public class Barber : BaseEntity
    {
        public string BarberName { get; set; }

        public string Experience { get; set; }

        public DateTime StartDate  { get; set; }

        public string BarberPhoto { get; set; }

        //Relacion Uno a Muchos

        public List<Appointment> Appointments { get; set; }
    }
}
