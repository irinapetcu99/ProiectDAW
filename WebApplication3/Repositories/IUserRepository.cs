using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;

namespace WebApplication3.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByUserAndPassword(string email, string password);
        User GetByEmail(string email);

        User GetUserAllDetails(int id);
        List<User> GetUsersAllDetails();
    }
}
