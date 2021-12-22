using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordSleep.Dto;
using BabyRecords_Server.features.BabyRecordSleep.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyRecords_Server.features.BabyRecordSleep.Controllers
{
    [Route("api/[controller]")]
    public class Baby_Record_SleepController : Controller
    {
        private readonly Baby_Record_SleepService _BabyRecordSleepService;
        public Baby_Record_SleepController(
            Baby_Record_SleepService baby_Record_SleepService
            )
        {
             _BabyRecordSleepService = baby_Record_SleepService;
        }
        // 取得單一時間睡眠紀錄
        [HttpGet("{babyid}")]
        public ActionResult<IEnumerable<Baby_Record_Entity>> GetSleepRecord(int babyid, DateTime time)
        {
            var Result = _BabyRecordSleepService.getSleepTime(babyid, time);
            return Result;
        }

        // 新增睡眠紀錄
        [HttpPost("{babyid}")]
        public ActionResult<Baby_Record_Entity> addSleepTime(int babyid,[FromBody] SleepDto value)
        {
            var insert = _BabyRecordSleepService.createSleepRecord(babyid, value);
            return CreatedAtAction(nameof(addSleepTime), new { id = insert.Id }, insert);

        }

        // 更新睡眠紀錄
        [HttpPut("{recordid}")]
        public ActionResult<Baby_Record_Entity> renewSleepTime(int recordid, [FromBody] SleepDto value)
        {
            var insert = _BabyRecordSleepService.updateSleepRecord(recordid, value);
            return CreatedAtAction(nameof(renewSleepTime), new { id = insert.Id }, insert);

        }

        // 刪除睡眠紀錄
        [HttpDelete("{recordid}")]
        public ActionResult<Baby_Record_Entity> deleteSleepTime(int recordid)
        {
            var insert = _BabyRecordSleepService.deleteSleepRecord(recordid);
            return CreatedAtAction(nameof(deleteSleepTime), new { id = insert.Id }, insert);

        }
    }
}
