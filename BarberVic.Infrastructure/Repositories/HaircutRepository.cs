using BarberVic.Application.Common.Interfaces;
using BarberVic.Domain.Entities;
using BarberVic.Infrastructure.Contexts.BarberVic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Infrastructure.Repositories
{
    public class HaircutRepository : IHaircutRepository
    {
        public static List<Haircut> haircuts = new List<Haircut>()
        {

        };
        private readonly BarberVicDbContext _haircutDbContext;

        public HaircutRepository(BarberVicDbContext haircutDbContext)
        {
            _haircutDbContext = haircutDbContext;
        }

        public Haircut CreateHaircut(Haircut haircut)
        {
            _haircutDbContext.Haircuts.Add(haircut);
            _haircutDbContext.SaveChanges();
            return haircut;
        }

        public Haircut DeleteHaircut(Haircut haircut)
        {
            _haircutDbContext.Haircuts.Remove(haircut);
            _haircutDbContext.SaveChanges();

            return null;
        }

        public List<Haircut> GetAllHaircuts()
        {
            return _haircutDbContext.Haircuts.ToList();
        }

    }
}
