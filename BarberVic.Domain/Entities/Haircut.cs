using BarberVic.Domain.BaseModel.BaseEntity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Domain.Entities
{
    public class Haircut : BaseEntity
    {
        public string HaircutName { get; set; }

        public float Price { get; set; }

        //Relacion Uno a Muchos

        public List<Appointment> Appointments { get; set; }
    }
}
