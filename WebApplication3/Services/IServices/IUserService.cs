using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Auth;
using WebApplication3.Entities;

namespace WebApplication3.Services.IServices
{
    public interface IUserService
    {
        User GetById(int id);
        List<User> GetAll();
        bool Register(RegisterRequest request);
        AuthResponse Login(AuthRequest request);
    }
}
