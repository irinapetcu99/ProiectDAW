using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Auth;
using WebApplication3.Entities;
using WebApplication3.Mapper;
using WebApplication3.Repositories;
using WebApplication3.Services.IServices;

namespace WebApplication3.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _password;
        public UserService(IUserRepository userRepository, IOptions<AppSettings> password)
        {
            this._userRepository = userRepository;
            this._password = password.Value;
        }

        public bool Register(RegisterRequest request)
        {
            var entity = request.ToUserExtension();

            if (_userRepository.GetByEmail(entity.Email) != null)
            {
                return false;
            }

            _userRepository.Create(entity);
            return _userRepository.SaveChanges();
        }

        public AuthResponse Login(AuthRequest request)
        {
            // find user
            var user = _userRepository.GetByUserAndPassword(request.Mail, request.Password);
            if (user == null)
                return null;

            // attach token
            var token = GenerateJwtForUser(user);

            // return user & token
            return new AuthResponse
            {
                Id = user.UserId,
                Email = user.Email,
                Token = token
            };
        }



        public List<User> GetAll()
        {
            return _userRepository.GetUsersAllDetails();
        }

        public User GetById(int id)
        {
            return _userRepository.GetUserAllDetails(id);
        }

        private string GenerateJwtForUser(User user)
        {
            var key = Encoding.ASCII.GetBytes("Icanputanystringinhere,becausethekeyisastring,andwillbetreatedasso");
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
