using BarberVic.Domain.BaseModel.BaseEntityDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Application.Dtos
{
    public class BarberDto : BaseEntityDto
    {
        public string BarberName { get; set; }

        public string Experience { get; set; }

        public DateTime StartDate { get; set; }

        public IFormFile BarberPhoto { get; set; }
    }
}
