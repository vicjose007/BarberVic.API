using BarberVic.Domain.BaseModel.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public DateTime InvoiceDate { get; set; }

        public float Total { get; set; }

        public string Details { get; set; }

        //Relacion Uno a Uno

        public Appointment Appointment { get; set; }

        public int AppointmentId { get; set; }
    }
}
