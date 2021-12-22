using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordHealth.Dto;
using BabyRecords_Server.features.BabyRecordHealth.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyRecords_Server.features.BabyRecordHealth.Controllers
{
    
    [Route("api/[controller]")]
    public class Baby_Record_HealthController : Controller
    {
        private readonly Baby_Record_HealthService _Baby_Record_HealthService;
        public Baby_Record_HealthController(
            Baby_Record_HealthService baby_Record_HealthService)
        {
             _Baby_Record_HealthService = baby_Record_HealthService;
        }


        // 取得單一時間健康紀錄
        [HttpGet("{babyid}")]
        public ActionResult<IEnumerable<Baby_Record_Entity>> GetHealthRecord(int babyid, DateTime time)
        {
            var Result = _Baby_Record_HealthService.getHealthTime(babyid, time);
            return Result;
        }

        // 新增寶寶健康紀錄
        [HttpPost("{babyid}")]
        public ActionResult<Baby_Record_Entity> addHealthRecord(int babyid,[FromBody] HealthDto value)
        {
            var insert = _Baby_Record_HealthService.createHealthRecord(babyid, value);
            return CreatedAtAction(nameof(addHealthRecord), new { id = insert.Id }, insert);
        }

        // 更新寶寶健康紀錄
        [HttpPut("{recordid}")]
        public ActionResult<Baby_Record_Entity> renewHealthRecord(int recordid, [FromBody] HealthDto value)
        {
            var insert = _Baby_Record_HealthService.updateHealthRecord(recordid, value);
            return CreatedAtAction(nameof(renewHealthRecord), new { id = insert.Id }, insert);

        }

        // 刪除寶寶健康紀錄
        [HttpDelete("{recordid}")]
        public ActionResult<Baby_Record_Entity> removeHealthRecord(int recordid)
        {
            var insert = _Baby_Record_HealthService.deleteHealthRecord(recordid);
            return CreatedAtAction(nameof(removeHealthRecord), new { id = insert.Id }, insert);

        }
    }
}
