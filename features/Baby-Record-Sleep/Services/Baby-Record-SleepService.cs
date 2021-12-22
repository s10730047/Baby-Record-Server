using System;
using BabyRecords_Server.Model;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordSleep.Dto;
using System.Collections.Generic;
using System.Linq;

namespace BabyRecords_Server.features.BabyRecordSleep.Services
{
    public class Baby_Record_SleepService
    {
        private readonly MyDbContext _MyDbContext;
        public Baby_Record_SleepService(
            MyDbContext myDbContext
            )
        {
            _MyDbContext = myDbContext;
        }
        //取得指定寶寶指定時間睡眠紀錄
        public List<Baby_Record_Entity> getSleepTime(int babyid, DateTime time)
        {
            var Record = from a in _MyDbContext.babyRecord
                         where a.BabyID == babyid && a.time == time && a.recordClass == 5
                         select a;
            return Record.ToList();
        }
        //新增睡眠紀錄
        public Baby_Record_Entity createSleepRecord(int babyid, SleepDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                BabyID = babyid,
                sleep = value.sleep,
                time = value.time,
                remark = value.remake,
                recordClass = 5
            };
            _MyDbContext.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
        //修改睡眠紀錄
        public Baby_Record_Entity updateSleepRecord(int recordid, SleepDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                Id = recordid,
                sleep = value.sleep,
                time = value.time,
                remark = value.remake
            };
            _MyDbContext.Update(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
        //刪除睡眠時間
        public Baby_Record_Entity deleteSleepRecord(int recordid)
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
