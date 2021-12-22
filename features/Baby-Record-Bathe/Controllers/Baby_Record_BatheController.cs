using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordBathe.Dto;
using Microsoft.AspNetCore.Mvc;
using BabyRecords_Server.features.BabyRecordBathe.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyRecords_Server.features.BabyRecordBathe.Controllers
{
    
    [Route("api/[controller]")]
    public class Baby_Record_BatheController : Controller
    {

        private readonly Baby_Record_BatheService _Baby_Record_BatheService;
        public Baby_Record_BatheController(
            Baby_Record_BatheService baby_Record_BatheService
            )
        {
             _Baby_Record_BatheService = baby_Record_BatheService;

        }



        // 取得單一時間洗澡紀錄
        [HttpGet("{babyid}")]
        public ActionResult<IEnumerable<Baby_Record_Entity>> GetbatheRecord(int babyid,DateTime time)
        {
            var Result = _Baby_Record_BatheService.getBatheTime(babyid, time);
            return Result;
        }

        // 新增洗澡紀錄
        [HttpPost("{babyid}")]
        public ActionResult<Baby_Record_Entity> addBatheTime(int babyid,[FromBody] BatheDto value)
        {

            var insert = _Baby_Record_BatheService.creatBatheTime(babyid,value);
            return CreatedAtAction(nameof(addBatheTime), new { id = insert.Id }, insert);

        }

        // 修改洗澡時間
        [HttpPut("{recordid}")]
        public ActionResult<Baby_Record_Entity> renewBatheTime(int recordid, [FromBody] BatheDto value)
        {
            var insert = _Baby_Record_BatheService.updateBatheTime(recordid, value);
            return CreatedAtAction(nameof(renewBatheTime), new { id = insert.Id }, insert);
        }

        // 刪除洗澡時間
        [HttpDelete("{recordid}")] 
        public ActionResult<Baby_Record_Entity> removeBatheTime(int recordid)
        {
            var insert = _Baby_Record_BatheService.deleteBatheTime(recordid);
            return CreatedAtAction(nameof(removeBatheTime), new { id = insert.Id }, insert);
        }
    }
}
