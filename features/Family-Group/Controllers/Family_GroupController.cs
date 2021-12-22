using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.FamilyGroup.Dto;
using BabyRecords_Server.features.FamilyGroup.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyRecords_Server.features.FamilyGroup.Controllers
{

    [Route("api/[controller]")]
    public class Family_GroupController : Controller
    {
        private readonly Family_GroupService _Family_GroupService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Family_GroupController(
            Family_GroupService family_GroupService,
            IHttpContextAccessor httpContextAccessor

            )
        {
             _Family_GroupService = family_GroupService;
            _httpContextAccessor = httpContextAccessor;

        }
        // 取得單一使用者群組
        [HttpGet]
        public IQueryable<int> getUserGroup()
        {
            var userID = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var group = _Family_GroupService.getUserGroup(Convert.ToInt16(userID));
            return group;
        }

        // 查詢群組成員id
        [HttpGet("GetGroupId")]
        public IQueryable<int> getGroupMember(int groupid)
        {
            var group = _Family_GroupService.getGroupMemberID(groupid);
            return group;
        }
        //取得群組寶寶
        [HttpGet("GetGroupBaby")]
        public List<Baby_info_Entity> getGroupBaby()
        {
            var userID = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var GroupId = _Family_GroupService.getUserGroup(Convert.ToInt16(userID));
            var baby = _Family_GroupService.getGroupBaby(Convert.ToInt16(GroupId));
            return baby.ToList();
        }
        //新增群組
        [HttpPost("AddGroup")]
        public ActionResult<Family_Group_Entity> AddGroup([FromBody] Family_GroupDto2 value)
        {
           var insert = _Family_GroupService.createFamilyGroup(value);
           return CreatedAtAction(nameof(AddGroup), new { id = insert.Id }, insert);

        }

        //新增群組成員
        [HttpPost("AddGroupMember")]
        public ActionResult<Family_Group_Member_Entity> AddGroupMember([FromBody] Family_GroupDto value)
        {
            var userId = _Family_GroupService.getUserID(value.Account);
            var insert = _Family_GroupService.createFamilyGroupMember(value,userId);
            return CreatedAtAction(nameof(AddGroupMember), new { id = insert.Id }, insert);
        }


        //刪除群組成員
        [HttpDelete("DeleteGroupMember")]
        public ActionResult<Family_Group_Member_Entity> RemoveGroupMember(int memberId)
        {
            var insert = _Family_GroupService.deleteFamilyGroupMember(memberId);
            return CreatedAtAction(nameof(RemoveGroupMember), new { id = insert.Id }, insert);
        }

        //刪除群組寶寶
        [HttpDelete("DeleteGroupBaby")]
        public ActionResult<Family_Group_Member_Entity> RemoveGroupBaby(int babyId)
        {
            var insert = _Family_GroupService.deleteFamilyGroupMember(babyId);
            return CreatedAtAction(nameof(RemoveGroupBaby), new { id = insert.Id }, insert);
        }

        //解散群組
        [HttpDelete("DeleteGroup")]
        public ActionResult<Family_Group_Member_Entity> RemoveGroup(int groupId)
        {
            var insert = _Family_GroupService.deleteFamilyGroup(groupId);
            return CreatedAtAction(nameof(RemoveGroup), new { id = insert.Id }, insert);
        }
    }
}
