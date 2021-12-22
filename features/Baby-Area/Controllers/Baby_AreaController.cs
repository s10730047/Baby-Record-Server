using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyArea.Dto;
using BabyRecords_Server.features.BabyArea.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyRecords_Server.features.BabyArea.Controllers
{

    [Route("api/[controller]")]
    public class Baby_AreaController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly Baby_AreaServices _Baby_AreaServices;
        public Baby_AreaController(
        IWebHostEnvironment env,
        Baby_AreaServices baby_AreaServices
        )
        {
            _env = env;
            _Baby_AreaServices = baby_AreaServices;
        }
        // 查詢危險事件
        [HttpGet("{babyid}")]
        public ActionResult<IEnumerable<Baby_Area_Entity>> getBabyArea(int babyid,DateTime time)
        {
            var result = _Baby_AreaServices.getBabyAreaTime(babyid, time);
            return result;
        }

        // 新增危險事件
        [HttpPost]
        public ActionResult<Baby_Area_Entity> AddAreaEvent(int babyId, IFormFile img)
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
            var insert = _Baby_AreaServices.postBabyArea(babyId, imgName);
            return CreatedAtAction(nameof(AddAreaEvent), new { id = insert.Id }, insert);
        }
    }
}
