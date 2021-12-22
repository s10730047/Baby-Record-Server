using System;
using System.Collections.Generic;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordDiaper.Dto;
using BabyRecords_Server.Model;
using System.Linq;

namespace BabyRecords_Server.features.BabyRecordDiaper.Services
{
    public class Baby_Record_DiaperService
    {
        private readonly MyDbContext _MyDbContext;
        public Baby_Record_DiaperService(
            MyDbContext myDbContext)
        {
            _MyDbContext = myDbContext;
        }

        //取得指定寶寶指定時間尿布紀錄
        public List<Baby_Record_Entity> getDiaperTime(int babyid, DateTime time)
        {
            var Record = from a in _MyDbContext.babyRecord
                         where a.BabyID == babyid && a.time == time && a.recordClass == 1
                         select a;
            return Record.ToList();
        }
        //新增換尿布時間
        public Baby_Record_Entity createDiaperTime(int babyid,DiaperDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                BabyID = babyid,
                diaper = value.Diaper,
                time = value.time,
                remark = value.remake,
                recordClass = 1
            };
            _MyDbContext.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }

        //更新尿布時間
        public Baby_Record_Entity updateDiaperTime(int recordid,DiaperDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                Id = recordid,
                diaper = value.Diaper,
                time = value.time,
                remark = value.remake
            };
            _MyDbContext.Update(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }

        //刪除尿布時間
        public Baby_Record_Entity deleteDaiperTime(int recordid)
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
