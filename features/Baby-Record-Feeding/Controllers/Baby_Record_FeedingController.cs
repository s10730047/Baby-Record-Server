using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordFeeding.Dto;
using BabyRecords_Server.features.BabyRecordFeeding.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyRecords_Server.features.BabyRecordFeeding.Controllers
{
    [Route("api/[controller]")]
    public class Baby_Record_FeedingController : Controller
    {
        private readonly Baby_Record_FeedingServices _Baby_Record_FeedingService;
        public Baby_Record_FeedingController(
            Baby_Record_FeedingServices baby_Record_FeedingServices
            )
        {
            _Baby_Record_FeedingService = baby_Record_FeedingServices;
        }
        // 取得單一時間餵食紀錄
        [HttpGet("{babyid}")]
        public ActionResult<IEnumerable<Baby_Record_Entity>> GetFeedingRecord(int babyid, DateTime time)
        { 
            var Result = _Baby_Record_FeedingService.getFeedingTime(babyid, time);
            return Result;
        }

        // 新增餵食時間
        [HttpPost("{babyid}")]
        public ActionResult<Baby_Record_Entity> addFeedingTime(int babyid,[FromBody] FeedingDto value)
        {
            var insert = _Baby_Record_FeedingService.createFeedingTime(babyid, value);
            return CreatedAtAction(nameof(addFeedingTime), new { id = insert.Id }, insert);

        }

        // 修改餵食時間
        [HttpPut("{recordid}")]
        public ActionResult<Baby_Record_Entity> renewFeedingTime(int recordid, [FromBody] FeedingDto value)
        {
            var insert = _Baby_Record_FeedingService.updateFeedingTime(recordid, value);
            return CreatedAtAction(nameof(renewFeedingTime), new { id = insert.Id }, insert);

        }

        // 刪除餵食時間
        [HttpDelete("{recordid}")]
        public ActionResult<Baby_Record_Entity> removeFeedingtime(int recordid)
        {
            var insert = _Baby_Record_FeedingService.deleteFeedingTime(recordid);
            return CreatedAtAction(nameof(removeFeedingtime), new { id = insert.Id }, insert);

        }
    }
}
