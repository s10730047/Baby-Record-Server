using System;
using BabyRecords_Server.Entities;
using BabyRecords_Server.Model;
using System.Linq;
using System.Collections.Generic;
namespace BabyRecords_Server.features.BabyFaceCover.Services
{
    public class Baby_FaceCoverService
    {
        private readonly MyDbContext _MyDbContext;
        public Baby_FaceCoverService(
            MyDbContext myDbContext
               )
        {
            _MyDbContext = myDbContext;
        }
        //查詢危險事件
        public List<Baby_FaceCover_Entity> getBabyFaceCoverTime(int babyId, DateTime time)
        {
            var result = from a in _MyDbContext.babyFaceCover
                         where a.BabyID == babyId && a.time == time
                         select a;
            return result.ToList();
        }
        //上傳口鼻覆蓋照片
        public Baby_FaceCover_Entity postBabyFaceCover(int babyId, string img)
        {
            Baby_FaceCover_Entity insert = new Baby_FaceCover_Entity
            {
                BabyID = babyId,
                EventImg = img,
                Event = "FaceCover"
            };
            _MyDbContext.babyFaceCover.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
    }
}
