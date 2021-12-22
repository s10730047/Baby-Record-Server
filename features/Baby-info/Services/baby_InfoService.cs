using System;
using BabyRecords_Server.features.Babyinfo.Dto;
using BabyRecords_Server.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Baby_info_Entity = BabyRecords_Server.Entities.Baby_info_Entity;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BabyRecords_Server.features.Babyinfo.Services
{
    public class baby_InfoService
    {
        private readonly MyDbContext _MyDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public baby_InfoService(
            MyDbContext myDbContext,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _MyDbContext = myDbContext;
            _httpContextAccessor = httpContextAccessor;
        }


        //新增寶寶
        public Baby_info_Entity createBaby([FromBody]baby_infoDto value,String img, int userID , int GroupId )
        {
            Baby_info_Entity insert = new Baby_info_Entity
            {
                UsersID = userID,
                familGroupID = GroupId,
                babyName = value.babyName,
                babyBirthday = value.babyBirthday,
                gender = value.gender,
                img = img
            };
            _MyDbContext.BabyInfo.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }

        //修改寶寶資訊
        public Baby_info_Entity updateBaby([FromBody] baby_infoDto value, String img, int babyID)
        {
            Baby_info_Entity insert = new Baby_info_Entity
            {
                Id = babyID,
                babyName = value.babyName,
                babyBirthday = value.babyBirthday,
                gender = value.gender,
                img = img
            };
            _MyDbContext.BabyInfo.Update(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }

        //刪除寶寶
        public Baby_info_Entity deleteBaby([FromBody] baby_infoDto value, String img, int babyId)
        {
            var insert = (from a in _MyDbContext.BabyInfo
                          where a.Id == babyId
                          select a).SingleOrDefault();
            _MyDbContext.BabyInfo.Remove(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }

        //取得單一帳號寶寶
        public List<Baby_info_Entity> getUsersAllbaby(int userid)
        {
            var baby = from a in _MyDbContext.BabyInfo
                       where a.UsersID == userid
                       select a;
            return baby.ToList();
        }

        internal object createBaby(baby_infoDto value, string imgName, short v, IQueryable<int> groupId)
        {
            throw new NotImplementedException();
        }
    }
}
