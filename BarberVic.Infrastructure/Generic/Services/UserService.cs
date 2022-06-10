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

    public class UserService : EntityCRUDService<User, UserDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IUnitOfWork<IBarberVicDbContext> uow, IUserRepository userRepository)
            : base(mapper, uow)
        {
            _userRepository = userRepository;
        }
        public User CreateUser(User user)
        {
            _userRepository.CreateUser(user);
            return user;
        }

        public User DeleteUser(User user)
        {
            _userRepository.DeleteUser(user);
            return user;
        }
        public List<User> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();

            return users;
        }
    }
}
