using System;
using System.Collections.Generic;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordFeeding.Dto;
using BabyRecords_Server.Model;
using System.Linq;
namespace BabyRecords_Server.features.BabyRecordFeeding.Services
{
    public class Baby_Record_FeedingServices
    {
        private readonly MyDbContext _MyDbContext;
        public Baby_Record_FeedingServices(
            MyDbContext myDbContext)
        {
            _MyDbContext = myDbContext;
        }

        //取得指定寶寶指定時間餵食紀錄
        public List<Baby_Record_Entity> getFeedingTime(int babyid, DateTime time)
        {
            var Record = from a in _MyDbContext.babyRecord
                         where a.BabyID == babyid && a.time == time && a.recordClass == 7
                         select a;
            return Record.ToList();
        }

        //新增餵食時間
        public Baby_Record_Entity createFeedingTime(int babyid,FeedingDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                BabyID = babyid,
                feeding = value.FeedType,
                milkMl = value.milkML,
                time = value.time,
                remark = value.remake,
                recordClass = 7
            };
            _MyDbContext.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
        //更新餵食時間
        public Baby_Record_Entity updateFeedingTime(int recordid,FeedingDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                Id = recordid,
                feeding = value.FeedType,
                milkMl = value.milkML,
                time = value.time,
                remark = value.remake
            };
            _MyDbContext.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
        //刪除餵食時間
        public Baby_Record_Entity deleteFeedingTime(int recordid)
        {
            var Delete = (from a in _MyDbContext.babyRecord
                          where a.Id == recordid
                          select a).SingleOrDefault();
            _MyDbContext.Remove(Delete);
            _MyDbContext.SaveChanges();
            return Delete;
        }
    }
}
