using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordTemp.Dto;
using BabyRecords_Server.features.BabyRecordTemp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyRecords_Server.features.BabyRecordTemp.Controllers
{
    [Route("api/[controller]")]
    public class Baby_Record_TempController : Controller
    {
        private readonly Baby_Record_TempService _BabyRecordTempService;
        public Baby_Record_TempController(
            Baby_Record_TempService baby_Record_TempService
            )
        {
             _BabyRecordTempService = baby_Record_TempService;
        }
        // 取得單一時間體溫紀錄
        [HttpGet("{babyid}")]
        public ActionResult<IEnumerable<Baby_Record_Entity>> GetTempRecord(int babyid, DateTime time)
        {
            var Result = _BabyRecordTempService.getTempTime(babyid, time);
            return Result;
        }

        // 新增體溫紀錄
        [HttpPost("{babyid}")]
        public ActionResult<Baby_Record_Entity> addTempRecord(int babyid,[FromBody] TempDto value)
        {
            var insert = _BabyRecordTempService.createTempRecord(babyid, value);
            return CreatedAtAction(nameof(addTempRecord), new { id = insert.Id }, insert);

        }

        // 更新體溫紀錄
        [HttpPut("{recordid}")]
        public ActionResult<Baby_Record_Entity> renewTempRecord(int recordid, [FromBody] TempDto value)
        {
            var insert = _BabyRecordTempService.updateTempRecord(recordid, value);
            return CreatedAtAction(nameof(renewTempRecord), new { id = insert.Id }, insert);

        }

        // 刪除體溫紀錄
        [HttpDelete("{recordid}")]
        public ActionResult<Baby_Record_Entity> removeTempRecord(int recordid)
        {
            var insert = _BabyRecordTempService.deleteTempRecord(recordid);
            return CreatedAtAction(nameof(removeTempRecord), new { id = insert.Id }, insert);

        }
    }
}
