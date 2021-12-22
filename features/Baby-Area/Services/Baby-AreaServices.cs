using System;
using BabyRecords_Server.Entities;
using BabyRecords_Server.Model;
using System.Linq;
using System.Collections.Generic;

namespace BabyRecords_Server.features.BabyArea.Services
{
    public class Baby_AreaServices
    {
        private readonly MyDbContext _MyDbContext;
            public Baby_AreaServices(
                MyDbContext myDbContext
                   )
            {
                _MyDbContext = myDbContext;
            }
        //查詢危險事件
        public List<Baby_Area_Entity> getBabyAreaTime(int babyId,DateTime time)
        {
            var result = from a in _MyDbContext.babyArea
                          where a.BabyID == babyId && a.time == time
                          select a;
            return result.ToList();
        }
        //上傳危險區域照片
        public Baby_Area_Entity postBabyArea(int babyId,string img)
        {
            Baby_Area_Entity insert = new Baby_Area_Entity
            {
                BabyID = babyId,
                EventImg = img,
                Event = "Area"
            };
            _MyDbContext.babyArea.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
    }
}
