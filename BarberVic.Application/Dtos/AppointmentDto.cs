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

        public string Barber { get; set; } = string.Empty;

        public DateTime Date { get; set; }
    }
}
