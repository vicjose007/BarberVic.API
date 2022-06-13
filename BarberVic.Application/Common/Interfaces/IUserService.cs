using BarberVic.Application.Common.Interfaces;
using BarberVic.Application.Dtos;
using BarberVic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Application.Common.Interfaces
{
    public interface IUserService : IEntityCRUDService<User, UserDto>
    {
        List<User> GetAllUsers();

        User CreateUser(User user);

        User DeleteUser(User userId);


    }
}
