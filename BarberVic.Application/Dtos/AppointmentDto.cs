using BarberVic.Domain.BaseModel.BaseEntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Application.Dtos
{
    public class AppointmentDto : BaseEntityDto
    {
        public int UserId { get; set; }

        public int BarberId { get; set; }

        public int HaircutId { get; set; }

        public DateTime Date { get; set; }

        
    }
}
