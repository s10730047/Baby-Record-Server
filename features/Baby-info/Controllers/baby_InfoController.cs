using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.Babyinfo.Dto;
using BabyRecords_Server.features.Babyinfo.Services;
using BabyRecords_Server.features.FamilyGroup.Services;
using BabyRecords_Server.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Baby_info_Entity = BabyRecords_Server.Entities.Baby_info_Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyRecords_Server.features.Babyinfo.Controllers
{
    
    [Route("api/[controller]")]
    public class baby_InfoController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly baby_InfoService _BabyInfoService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Family_GroupService _Family_GroupService;
        public baby_InfoController(
            IWebHostEnvironment env,
            baby_InfoService Baby_InfoService,
            IHttpContextAccessor httpContextAccessor,
            Family_GroupService family_GroupService

            )
        {
            _env = env;
            _BabyInfoService = Baby_InfoService;
            _httpContextAccessor = httpContextAccessor;
            _Family_GroupService = family_GroupService;
        }


        // 取得單一帳號寶寶
        [HttpGet("{userid}")]
        public ActionResult<IEnumerable<Baby_info_Entity>> getUserAllbaby(int userid)
        {
            var Result = _BabyInfoService.getUsersAllbaby(userid);
            if(Result == null)
            {
                return NotFound("尚未新增寶寶");
            }
            else
            {
                return Result;

            }

        }
        // 新增寶寶
        [HttpPost("{groupId}")]
        public ActionResult<Baby_info_Entity> addBaby(baby_infoDto value,IFormFile img,int groupId)
        {
            var userID = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var rootPath = _env.ContentRootPath + "/upload/";
            var imgName = img.FileName;
            if (img.Length > 0)
            {
                var fileName = img.FileName;
                using (var stream = System.IO.File.Create(rootPath+fileName))
                {
                    img.CopyTo(stream);
                }               
            }
            var insert = _BabyInfoService.createBaby(value, imgName, Convert.ToInt16(userID), groupId);
            return CreatedAtAction(nameof(addBaby), new { id = insert.Id }, insert);
        }
        // 更新寶寶
        [HttpPut("{babyid}")]
        public ActionResult<Baby_info_Entity> renewBaby(baby_infoDto value, IFormFile img, int babyid)
        {
            var rootPath = _env.ContentRootPath + "/upload/";
            var imgName = img.FileName;
            if (img.Length > 0)
            {
                var fileName = img.FileName;
                using (var stream = System.IO.File.Create(rootPath + fileName))
                {
                    img.CopyTo(stream);
                }
            }
            var insert = _BabyInfoService.updateBaby(value,imgName, babyid);
            return CreatedAtAction(nameof(renewBaby), new { id = insert.Id }, insert);

        }

        // 刪除寶寶
        [HttpDelete("{babyid}")]
        public ActionResult<Baby_info_Entity> removeBaby(baby_infoDto value, IFormFile img, int babyid)
        {
            var imgName = img.FileName;
            var insert = _BabyInfoService.deleteBaby(value, imgName, babyid);
            return CreatedAtAction(nameof(removeBaby), new { id = insert.Id }, insert);

        }
    }
}
