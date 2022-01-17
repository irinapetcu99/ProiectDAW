using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;
using WebApplication3.Repositories;
using WebApplication3.Services.IServices;

namespace WebApplication3.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetUsersAllDetails();
        }

        public User GetById(int id)
        {
            return _userRepository.GetUserAllDetails(id);
        }
    }
}
