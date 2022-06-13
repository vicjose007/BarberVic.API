using BarberVic.Application.Dtos;
using BarberVic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Application.Common.Interfaces
{
    public interface IBarberService : IEntityCRUDService<Barber, BarberDto>
    {
        List<Barber> GetAllBarbers();

        Barber CreateBarber(Barber barber);

        Barber DeleteBarber(Barber barberId);


    }
}
