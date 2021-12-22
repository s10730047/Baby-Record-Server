using System;
using BabyRecords_Server.Model;
using BabyRecords_Server.Entities;
using System.Collections.Generic;
using System.Linq;
using BabyRecords_Server.features.FamilyGroup.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BabyRecords_Server.features.FamilyGroup.Services
{
    public class Family_GroupService
    {
        private readonly MyDbContext _MyDbContext;
        public Family_GroupService(
          MyDbContext myDbContext
            )
        {
            _MyDbContext = myDbContext;
        }
        //查詢使用者帳號
        public User_Entity getUserAccount(string account)
        {
            var user = (from a in _MyDbContext.Users
                        where a.account == account
                        select a).SingleOrDefault();
            return user;
        }
        
        //查詢使用者ID
        public int getUserID(string Account)
        {
            var user = (from a in _MyDbContext.Users
                        where a.account == Account
                        select a).SingleOrDefault();
            return user.Id;
        }

        //查詢群組成員
        public List<Family_Group_Member_Entity> getGroupMember(int groupid)
        {
            var group = from a in _MyDbContext.familyGroupMember
                        where a.Id == groupid
                        select a;
            return group.ToList();
        }

        //查詢單一使用者群組
        public IQueryable<int> getUserGroup(int userid)
        {
            var group = from a in _MyDbContext.familyGroupMember              
                        where a.usersID == userid
                        select a.familyGroupID;
            return group;
        }

        //查詢群組成員id
        public IQueryable<int> getGroupMemberID(int familyid)
        {
            var groupUserID = from a in _MyDbContext.familyGroupMember
                        where a.familyGroupID == familyid
                        select a.usersID;
            return groupUserID;
        }
        //取得群組寶寶
        public List<Baby_info_Entity> getGroupBaby(int groupid)
        {
            var baby = from a in _MyDbContext.BabyInfo
                       where a.familGroupID == groupid
                       select a;
            return baby.ToList();
        }
        //新增群組
        public Family_Group_Entity createFamilyGroup([FromBody] Family_GroupDto2 value)
        {
            Family_Group_Entity insert = new Family_Group_Entity
            {
                familyGroupName = value.FamilyName
            };
            _MyDbContext.familyGroup.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
        //新增群組成員
        public Family_Group_Member_Entity createFamilyGroupMember(Family_GroupDto value,int userID)
        {
            Family_Group_Member_Entity insert = new Family_Group_Member_Entity
            {
                usersID = userID,
                familyGroupID = value.Id,
            };
            _MyDbContext.familyGroupMember.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }

        //刪除群組成員
        public Family_Group_Member_Entity deleteFamilyGroupMember(int memberID)
        {
            var member = (from a in _MyDbContext.familyGroupMember
                         where a.familyGroupID == memberID
                         select a).SingleOrDefault();
            _MyDbContext.familyGroupMember.Remove(member);
            _MyDbContext.SaveChanges();
            return member;
        }

        //刪除群組寶寶
        public Baby_info_Entity deleteFamilyGroupBaby(int babyID)
        {
            var baby = (from a in _MyDbContext.BabyInfo
                          where a.Id == babyID
                          select a).SingleOrDefault();
            _MyDbContext.Remove(baby);
            _MyDbContext.SaveChanges();
            return baby;
        }

        //解散群組
        public Family_Group_Entity deleteFamilyGroup(int groupID)
        {
            var group = (from a in _MyDbContext.familyGroup
                          where a.Id == groupID
                         select a).SingleOrDefault();
            _MyDbContext.familyGroup.Remove(group);
            _MyDbContext.SaveChanges();
            return group;
        }
    }
}
