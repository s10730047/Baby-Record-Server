using System;
using System.Collections.Generic;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordTemp.Dto;
using BabyRecords_Server.Model;
using System.Linq;
namespace BabyRecords_Server.features.BabyRecordTemp.Services
{
    public class Baby_Record_TempService
    {
        private readonly MyDbContext _MyDbContext;
        public Baby_Record_TempService(
             MyDbContext myDbContext
            )
        {
            _MyDbContext = myDbContext;
        }
        //取得指定寶寶指定時間體溫紀錄
        public List<Baby_Record_Entity> getTempTime(int babyid, DateTime time)
        {
            var Record = from a in _MyDbContext.babyRecord
                         where a.BabyID == babyid && a.time == time && a.recordClass == 6
                         select a;
            return Record.ToList();
        }
        //新增體溫紀錄
        public Baby_Record_Entity createTempRecord(int babyid, TempDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                BabyID = babyid,
                babyTempWay = value.HowToGetTemp,
                temp = value.temp,
                time = value.time,
                remark = value.remake,
                recordClass = 6
            };
            _MyDbContext.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
        //更新體溫紀錄
        public Baby_Record_Entity updateTempRecord(int recordid, TempDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                Id = recordid,
                babyTempWay = value.HowToGetTemp,
                temp = value.temp,
                time = value.time,
                remark = value.remake
            };
            _MyDbContext.Update(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
        //刪除體溫紀錄
        public Baby_Record_Entity deleteTempRecord(int recordid)
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
