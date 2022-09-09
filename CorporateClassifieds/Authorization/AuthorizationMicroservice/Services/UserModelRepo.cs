using Authorization.Infrastructure;
using Authorization.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace Authorization.Services
{
    public class UserModelRepo : IUserModel
    {
        private IConfiguration _config;
        private List<UserModel> Listuser;

        public UserModelRepo(IConfiguration config)
        {
            _config = config;
            Listuser = new List<UserModel>()
            {
                new UserModel{EmployeeId=2159447,Password="12345"},
                new UserModel{EmployeeId=2142912,Password="12345"},
                new UserModel{EmployeeId=2144009,Password="12345"},
                new UserModel{EmployeeId=2141156,Password="12345"},
                new UserModel{EmployeeId=2159071,Password="12345"},
                new UserModel{EmployeeId=2142922,Password="12345"},
            };
        }
        public UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = Listuser.FirstOrDefault(z => z.EmployeeId == login.EmployeeId && z.Password == login.Password);
            return user;
        }

        public string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
