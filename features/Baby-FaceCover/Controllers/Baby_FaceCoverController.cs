using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyFaceCover.Dto;
using BabyRecords_Server.features.BabyFaceCover.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyRecords_Server.features.BabyFaceCover.Controllers
{
    [Route("api/[controller]")]
    public class Baby_FaceCoverController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly Baby_FaceCoverService _Baby_FaceCoverService;
        public Baby_FaceCoverController(
        IWebHostEnvironment env,
        Baby_FaceCoverService baby_FaceCoverService
        )
        {
            _env = env;
            _Baby_FaceCoverService = baby_FaceCoverService;
        }
        // 查詢危險事件
        [HttpGet("{babyid}")]
        public ActionResult<IEnumerable<Baby_FaceCover_Entity>> getFaceCover(int babyid, DateTime time)
        {
            var result = _Baby_FaceCoverService.getBabyFaceCoverTime(babyid, time);
            return result;
        }

        // 新增危險事件
        [HttpPost]
        public ActionResult<Baby_FaceCover_Entity> AddFaceCover(int babyId, IFormFile img)
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
            var insert = _Baby_FaceCoverService.postBabyFaceCover(babyId, imgName);
            return CreatedAtAction(nameof(AddFaceCover), new { id = insert.Id }, insert);
        }
    }
}
