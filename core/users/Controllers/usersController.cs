using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyRecords_Server.core.users.Dto;
using BabyRecords_Server.Model;
using Microsoft.AspNetCore.Mvc;
using BabyRecords_Server.Entities;
using BabyRecords_Server.core.tools;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using BabyRecords_Server.core.users.Services;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyRecords_Server.core.users.Controllers
{
    [Route("api/users")]
    public class usersController : Controller
    {
        private readonly MyDbContext _MyDbContext;
        private readonly Cryptography _Cryptography;
        private readonly IConfiguration _Configuration;
        private readonly usersServices _UserService;
        private readonly Jwt _Jwt;
        public usersController(
            MyDbContext myDbContext,
            Cryptography cryptography,
            IConfiguration configuration,
            usersServices userServices,
            Jwt jwt
            )
        {
            _MyDbContext = myDbContext;
            _Configuration = configuration;
            _Cryptography = cryptography;
            _UserService = userServices;
            _Jwt = jwt;



        }
        // GET: api/valuess
        [HttpGet]
        public  ActionResult<IEnumerable<User_Entity>> GetAll()
        {
             
            return  _MyDbContext.Users;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User_Entity> Get(int id)
        {
            var result = _MyDbContext.Users.Find(id);
            return result;
        }

        //註冊帳號
        [HttpPost]
        //[AllowAnonymous]
        public   ActionResult<User_Entity> CreatUser([FromBody] registerDto value)
        {
            if (value.password != value.reqpassword)
            {
                return NotFound("密碼輸入錯誤");
            }
             var insert = _UserService.Register(value);
            return CreatedAtAction(nameof(CreatUser), new { id = insert.Id }, insert);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public string login([FromBody] loginDto value)
        {
            var user = _UserService.login(value);
            if (user != null)
            {
                var hashpassworded = user.password;
                var salt = user.salt;
                var hashpassword = _Cryptography.CreateHash(value.password, salt);
                if(hashpassworded == hashpassword)
                {
                    var token =_Jwt.jwt(user.account, user.Id);

                    return "登入成功"+token;
                }else if(hashpassword != hashpassworded)
                {
                    return "密碼錯誤";
                }              
            }
            return "查無此人";
        }
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


    }
}
