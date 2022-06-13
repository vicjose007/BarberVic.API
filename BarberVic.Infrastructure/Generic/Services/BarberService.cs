using AutoMapper;
using BarberVic.Application.Common.Interfaces;
using BarberVic.Application.Dtos;
using BarberVic.Domain.Entities;
using BarberVic.Infrastructure.Contexts.BarberVic;
using BarberVic.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Infrastructure.Generic.Services
{

    public class BarberService : EntityCRUDService<Barber, BarberDto>, IBarberService
    {
        private readonly IBarberRepository _barberRepository;
        public BarberService(IMapper mapper, IUnitOfWork<IBarberVicDbContext> uow, IBarberRepository barberRepository)
            : base(mapper, uow)
        {
            _barberRepository = barberRepository;
        }
        public Barber CreateBarber(Barber barber)
        {
            _barberRepository.CreateBarber(barber);
            return barber;
        }

        public Barber DeleteBarber(Barber barber)
        {
            _barberRepository.DeleteBarber(barber);
            return barber;
        }
        public List<Barber> GetAllBarbers()
        {
            var barbers = _barberRepository.GetAllBarbers();

            return barbers;
        }
    }
}
