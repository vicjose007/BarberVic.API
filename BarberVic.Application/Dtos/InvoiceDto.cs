using BarberVic.Domain.BaseModel.BaseEntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Application.Dtos
{
    public class InvoiceDto : BaseEntityDto
    {
        public DateTime InvoiceDate { get; set; }

        public float Total { get; set; }

        public string Details { get; set; }

        public int AppointmentId { get; set; }
    }
}
