using BarberVic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Application.Common.Interfaces
{
    public interface IHaircutRepository
    {
        List<Haircut> GetAllHaircuts();

        Haircut CreateHaircut(Haircut haircut);

        Haircut DeleteHaircut(Haircut haircut);


    }
}
