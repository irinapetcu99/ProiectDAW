using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Auth;
using WebApplication3.Entities;

namespace WebApplication3.Mapper
{
    public static class UserMapper
    {
        public static User ToUserExtension(this RegisterRequest request)
        {
            return new User
            {
                Email = request.Mail,
                Password = request.Password
            };
        }
    }
}
