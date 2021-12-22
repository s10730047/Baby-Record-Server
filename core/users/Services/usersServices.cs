using System;
using BabyRecords_Server.core.tools;
using BabyRecords_Server.Model;
using Microsoft.Extensions.Configuration;
using BabyRecords_Server.Entities;
using BabyRecords_Server.core.users.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BabyRecords_Server.core.users.Services
{
    public class usersServices
    {
        private readonly MyDbContext _MyDbContext;
        private readonly Cryptography _Cryptography;
        private readonly IConfiguration _Configuration;

        public usersServices(
            MyDbContext myDbContext,
            Cryptography cryptography,
            IConfiguration configuration)
        {
            _MyDbContext = myDbContext;
            _Configuration = configuration;
            _Cryptography = cryptography;
        }
        public User_Entity Register([FromBody] registerDto value)
        {
            var salt = _Cryptography.CreateSalt(Convert.ToInt32(value.password.Length));
            var hashPassword = _Cryptography.CreateHash(value.password, salt);
            User_Entity insert = new User_Entity
            {
                name = value.name,
                account = value.account,
                password = hashPassword,
                salt = salt,
                email = value.email
            };
            _MyDbContext.Users.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }

        public User_Entity login([FromBody]loginDto value)
        {
            var user = (from a in _MyDbContext.Users
                        where a.account == value.account
                        select a).SingleOrDefault();
            return user;
        }
        
    }
}
