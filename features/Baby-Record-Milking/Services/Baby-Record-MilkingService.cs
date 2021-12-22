using System;
using BabyRecords_Server.Model;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordMilking.Dto;
using System.Collections.Generic;
using System.Linq;

namespace BabyRecords_Server.features.BabyRecordMilking.Services
{
    public class Baby_Record_MilkingService
    {
        private readonly MyDbContext _MyDbContext;
        public Baby_Record_MilkingService(
             MyDbContext myDbContext
            )
        {
            _MyDbContext = myDbContext;
        }

        //取得指定寶寶指定時間母乳紀錄
        public List<Baby_Record_Entity> getMilkingTime(int babyid, DateTime time)
        {
            var Record = from a in _MyDbContext.babyRecord
                         where a.BabyID == babyid && a.time == time && a.recordClass == 4
                         select a;
            return Record.ToList();
        }
        //新增母乳紀錄
        public Baby_Record_Entity createMilkingRecord(int babyid, MilkingDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                BabyID = babyid,
                milkingMl = value.milkingML,
                time = value.time,
                remark = value.remake,
                recordClass = 4
            };
            _MyDbContext.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
        //更新母乳紀錄
        public Baby_Record_Entity updateMilkingRecord(int recordid, MilkingDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                Id = recordid,
                milkingMl = value.milkingML,
                time = value.time,
                remark = value.remake
            };
            _MyDbContext.Update(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
        //刪除母乳紀錄
        public Baby_Record_Entity deleteMilkingRecord(int recordid)
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
