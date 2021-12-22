using System;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordGrowing.Dto;
using BabyRecords_Server.Model;
using System.Linq;
using System.Collections.Generic;

namespace BabyRecords_Server.features.BabyRecordGrowing.Services
{
    public class Baby_Record_GrowingService
    {
        private readonly MyDbContext _MyDbContext;
        public Baby_Record_GrowingService(
            MyDbContext myDbContext
            )
        {
            _MyDbContext = myDbContext;
        }

        //取得指定寶寶指定時間成長紀錄
        public List<Baby_Record_Entity> getGrowingTime(int babyid, DateTime time)
        {
            var Record = from a in _MyDbContext.babyRecord
                         where a.BabyID == babyid && a.time == time && a.recordClass == 2
                         select a;
            return Record.ToList();
        }

        //新增成長紀錄
        public Baby_Record_Entity createGrowingRecord(int babyid,GrowingDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                BabyID = babyid,
                height = value.height,
                weight = value.weight,
                head = value.head,
                time = value.time,
                remark = value.remake,
                recordClass = 2
            };
            _MyDbContext.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
        //更新成長紀錄
        public Baby_Record_Entity updateGrowingRecord(int babyid, GrowingDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                BabyID = babyid,
                height = value.height,
                weight = value.weight,
                head = value.head,
                time = value.time,
                remark = value.remake
            };
            _MyDbContext.Update(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
        //刪除成長紀錄
        public Baby_Record_Entity deleteGrowingRecord(int recordid)
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
