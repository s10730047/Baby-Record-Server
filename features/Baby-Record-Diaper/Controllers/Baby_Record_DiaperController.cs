using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyRecords_Server.features.BabyRecordDiaper.Services;
using Microsoft.AspNetCore.Mvc;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordDiaper.Dto;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyRecords_Server.features.BabyRecordDiaper.Controllers
{
    [Route("api/[controller]")]
    public class Baby_Record_DiaperController : Controller
    {
        private readonly Baby_Record_DiaperService _Baby_Record_DiaperService;
        public Baby_Record_DiaperController(
            Baby_Record_DiaperService baby_Record_DiaperService
            )
        {
             _Baby_Record_DiaperService = baby_Record_DiaperService;

        }       
        // 取得單一時間尿布紀錄
        [HttpGet("{babyid}")]
        public ActionResult<IEnumerable<Baby_Record_Entity>> GetDiperRecord(int babyid,DateTime time)
        {
            var Result = _Baby_Record_DiaperService.getDiaperTime(babyid, time);
            return Result;
        }

        // 新增換尿布時間
        [HttpPost("{babyid}")]
        public ActionResult<Baby_Record_Entity> addDaipertime(int babyid, [FromBody] DiaperDto value)
        {
            var insert = _Baby_Record_DiaperService.createDiaperTime(babyid, value);
            return CreatedAtAction(nameof(addDaipertime), new { id = insert.Id }, insert);
        }
        // 修改換尿布時間
        [HttpPut("{recordid}")]
        public ActionResult<Baby_Record_Entity> renewDaipertime(int recordid, [FromBody] DiaperDto value)
        {
            var insert = _Baby_Record_DiaperService.updateDiaperTime(recordid, value);
            return CreatedAtAction(nameof(renewDaipertime), new { id = insert.Id }, insert);
        }

        // 刪除換尿布時間
        [HttpDelete("{recordid}")]
        public ActionResult<Baby_Record_Entity> removeDaipertime(int recordid)
        {
            var insert = _Baby_Record_DiaperService.deleteDaiperTime(recordid);
            return CreatedAtAction(nameof(removeDaipertime), new { id = insert.Id }, insert);

        }
    }
}
