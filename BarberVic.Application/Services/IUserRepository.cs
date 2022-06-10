using BarberVic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberVic.Application.Services
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User CreateUser(User user);

        User DeleteUser(User user);


    }
}