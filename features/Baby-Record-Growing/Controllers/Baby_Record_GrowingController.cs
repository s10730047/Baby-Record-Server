using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordGrowing.Dto;
using BabyRecords_Server.features.BabyRecordGrowing.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyRecords_Server.features.BabyRecordGrowing.Controllers
{
    [Route("api/[controller]")]
    public class Baby_Record_GrowingController : Controller
    {
        private readonly Baby_Record_GrowingService _Baby_Record_GrowingService;
        public Baby_Record_GrowingController(
            Baby_Record_GrowingService baby_Record_GrowingService)
        {
            _Baby_Record_GrowingService = baby_Record_GrowingService;
        }


        // 取得單一時間餵食紀錄
        [HttpGet("{babyid}")]
        public ActionResult<IEnumerable<Baby_Record_Entity>> GetGrowingRecord(int babyid, DateTime time)
        {
            var Result = _Baby_Record_GrowingService.getGrowingTime(babyid, time);
            return Result;
        }

        // 新增成長紀錄
        [HttpPost("{babyid}")]
        public ActionResult<Baby_Record_Entity> addGrowingRecord(int babyid,[FromBody] GrowingDto value)
        {
            var insert = _Baby_Record_GrowingService.createGrowingRecord(babyid, value);
            return CreatedAtAction(nameof(addGrowingRecord), new { id = insert.Id }, insert);

        }

        // 更新成長紀錄
        [HttpPut("{recordid}")]
        public ActionResult<Baby_Record_Entity> renewGrowingRecord(int recordid, [FromBody] GrowingDto value)
        {
            var insert = _Baby_Record_GrowingService.updateGrowingRecord(recordid, value);
            return CreatedAtAction(nameof(renewGrowingRecord), new { id = insert.Id }, insert);

        }

        // 刪除成長紀錄
        [HttpDelete("{recordid}")]
        public ActionResult<Baby_Record_Entity> removeGrowingRecord(int recordid)
        {
            var insert = _Baby_Record_GrowingService.deleteGrowingRecord(recordid);
            return CreatedAtAction(nameof(removeGrowingRecord), new { id = insert.Id }, insert);

        }
    }
}
