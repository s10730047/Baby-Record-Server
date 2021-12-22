using System;
using BabyRecords_Server.Entities;

namespace BabyRecords_Server.features.FamilyGroup.Dto
{
    public class Family_GroupDto
    {
        public int Id { get; set; }

        public string Account { get; set; }

        public virtual User_Entity user { get; set; }

        public virtual Family_Group_Member_Entity familyGroupMember { get; set; }

        public virtual Baby_info_Entity baby { get; set; }

        public string FamilyName { get; set; }

        public string MemberName { get; set; }

    }
}
