using BarberVic.Domain.BaseModel.BaseEntityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Application.Dtos
{
    public class HaircutDto : BaseEntityDto
    {
        public string HaircutName { get; set; }

        public float Price { get; set; }
    }
}
