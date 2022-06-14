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

    public class HaircutService : EntityCRUDService<Haircut, HaircutDto>, IHaircutService
    {
        private readonly IHaircutRepository _haircutRepository;
        
        public HaircutService(IMapper mapper, IUnitOfWork<IBarberVicDbContext> uow, IHaircutRepository haircutRepository)
            : base(mapper, uow)
        {
            _haircutRepository = haircutRepository;
            
        }
        public Haircut CreateHaircut(Haircut haircut)
        {
            
            _haircutRepository.CreateHaircut(haircut);

            return haircut;
        }

        public Haircut DeleteHaircut(Haircut haircut)
        {
            _haircutRepository.DeleteHaircut(haircut);
            return haircut;
        }
        public List<Haircut> GetAllHaircuts()
        {
            var haircuts = _haircutRepository.GetAllHaircuts();

            return haircuts;
        }
    }
}
