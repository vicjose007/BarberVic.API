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
    public class BarberRepository : IBarberRepository
    {
        public static List<Barber> barbers = new List<Barber>()
        {

        };
        private readonly BarberVicDbContext _barberDbContext;

        public BarberRepository(BarberVicDbContext barberDbContext)
        {
            _barberDbContext = barberDbContext;
        }

        public Barber CreateBarber(Barber barber)
        {
            _barberDbContext.Barbers.Add(barber);
            _barberDbContext.SaveChanges();
            return barber;
        }

        public Barber DeleteBarber(Barber barber)
        {
            _barberDbContext.Barbers.Remove(barber);
            _barberDbContext.SaveChanges();

            return null;
        }

        public List<Barber> GetAllBarbers()
        {
            return _barberDbContext.Barbers.ToList();
        }

    }
}
