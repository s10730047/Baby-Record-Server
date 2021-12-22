using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordMilking.Dto;
using BabyRecords_Server.features.BabyRecordMilking.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyRecords_Server.features.BabyRecordMilking.Controllers
{
    [Route("api/[controller]")]
    public class Baby_Record_MilkingController : Controller
    {
        private readonly Baby_Record_MilkingService _Baby_Record_MilkingService;
        public Baby_Record_MilkingController(
            Baby_Record_MilkingService baby_Record_MilkingService)
        {
            _Baby_Record_MilkingService = baby_Record_MilkingService;
        }

        // 取得單一時間母乳紀錄
        [HttpGet("{babyid}")]
        public ActionResult<IEnumerable<Baby_Record_Entity>> GetMilkingRecord(int babyid, DateTime time)
        {
            var Result = _Baby_Record_MilkingService.getMilkingTime(babyid, time);
            return Result;
        }

        // 新增母乳紀錄
        [HttpPost("{babyid}")]
        public ActionResult<Baby_Record_Entity> addMilkingRecord(int babyid,[FromBody] MilkingDto value)
        {
            var insert = _Baby_Record_MilkingService.createMilkingRecord(babyid, value);
            return CreatedAtAction(nameof(addMilkingRecord), new { id = insert.Id }, insert);

        }

        // 更新母乳紀錄
        [HttpPut("{recordid}")]
        public ActionResult<Baby_Record_Entity> renewMilkingRecord(int recordid, [FromBody] MilkingDto value)
        {
            var insert = _Baby_Record_MilkingService.updateMilkingRecord(recordid, value);
            return CreatedAtAction(nameof(renewMilkingRecord), new { id = insert.Id }, insert);

        }

        // 刪除母乳紀錄
        [HttpDelete("{recordid}")]
        public ActionResult<Baby_Record_Entity> removeMilkingRecord(int recordid)
        {
            var insert = _Baby_Record_MilkingService.deleteMilkingRecord(recordid);
            return CreatedAtAction(nameof(removeMilkingRecord), new { id = insert.Id }, insert);

        }
    }
}
