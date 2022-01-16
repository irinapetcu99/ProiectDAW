using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Entities;

namespace WebApplication3.Services.IServices
{
        public interface IRoleService
        {
            Role Create(Role role);
            Role Get(int id);
            Role Update(Role role);
            bool Delete(int id);
            List<Role> GetAll();
        }
}
