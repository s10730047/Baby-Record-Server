using System;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordBathe.Dto;
using BabyRecords_Server.Model;
using System.Linq;
using System.Collections.Generic;

namespace BabyRecords_Server.features.BabyRecordBathe.Services
{
    public class Baby_Record_BatheService
    {
        private readonly MyDbContext _MyDbContext;
        public Baby_Record_BatheService(
               MyDbContext myDbContext
                                        )
        {
            _MyDbContext = myDbContext;
        }
        //新增洗澡時間
        public Baby_Record_Entity creatBatheTime(int babyid, BatheDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                BabyID = babyid,
                time = value.time,
                remark = value.remake,
                recordClass = 7
            };
            _MyDbContext.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }

        //更新洗澡時間
        public Baby_Record_Entity updateBatheTime(int recordid, BatheDto value)
        {
            Baby_Record_Entity insert = new Baby_Record_Entity
            {
                Id = recordid,
                time = value.time,
                remark = value.remake
            };
            _MyDbContext.Update(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }

        //刪除洗澡時間
        public Baby_Record_Entity deleteBatheTime(int recordid)
        {
            var Delete = (from a in _MyDbContext.babyRecord
                          where a.Id == recordid
                          select a).SingleOrDefault();
            _MyDbContext.Remove(Delete);
            _MyDbContext.SaveChanges();
            return Delete;
        }
        //取得指定寶寶指定時間洗澡紀錄
        public List<Baby_Record_Entity> getBatheTime(int babyid, DateTime time)
        {
            var Record = from a in _MyDbContext.babyRecord
                         where a.BabyID == babyid && a.time == time && a.recordClass == 8
                         select a;
            return Record.ToList();
        }
    }
}