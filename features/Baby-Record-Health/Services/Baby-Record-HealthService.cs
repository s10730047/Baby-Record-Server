using System;
using BabyRecords_Server.Model;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordHealth.Dto;
using System.Collections.Generic;
using System.Linq;

namespace BabyRecords_Server.features.BabyRecordHealth.Services
{
    public class Baby_Record_HealthService
    {
        private readonly MyDbContext _MyDbContext;
        public Baby_Record_HealthService(
            MyDbContext myDbContext
            )
        {
            _MyDbContext = myDbContext;
        }
        //取得指定寶寶指定時間健康紀錄
        public List<Baby_Record_Entity> getHealthTime(int babyid, DateTime time)
        {
            var Record = from a in _MyDbContext.babyRecord
                         where a.BabyID == babyid && a.time == time && a.recordClass == 3
                         select a;
            return Record.ToList();
        }
        //新增寶寶健康紀錄
        public Baby_Record_Entity createHealthRecord(int babyid, HealthDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                BabyID = babyid,
                healthWay = value.healthWay,
                time = value.time,
                remark = value.remake,
                recordClass = 3
            };
            _MyDbContext.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
        //更新寶寶健康紀錄
        public Baby_Record_Entity updateHealthRecord(int recordid, HealthDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                Id = recordid,
                healthWay = value.healthWay,
                time = value.time,
                remark = value.remake
            };
            _MyDbContext.Update(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
        //刪除寶寶健康紀錄
        public Baby_Record_Entity deleteHealthRecord(int recordid)
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
