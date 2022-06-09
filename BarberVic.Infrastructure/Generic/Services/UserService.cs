using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberVic.Application.Common.Interfaces;
using BarberVic.Application.Dtos;
using BarberVic.Domain.Entities;
using BarberVic.Infrastructure.Contexts.BarberVic;
using BarberVic.Infrastructure.Generic;
using BarberVic.Infrastructure.UnitOfWorks;

namespace BarberVic.Application.Services
{
    public interface IUserServiceService : IEntityCRUDService<User, UserDto>
    {
        // Agregar mas metodo al servicio
    }

    public class UserService : EntityCRUDService<User, UserDto>, IUserServiceService
    {
        public UserService(IMapper mapper, IUnitOfWork<IBarberVicDbContext> uow)
            : base(mapper, uow)
        {
        }
    }
}
