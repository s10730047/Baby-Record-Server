using System;
using BabyRecords_Server.Entities;

namespace BabyRecords_Server.features.Babyinfo.Dto
{
    public class baby_infoDto
    {
        public int Id { get; set; }

        public virtual Family_Group_Entity familGroup { get; set; }

        public string babyName { get; set; }

        public DateTime babyBirthday { get; set; }

        public string gender { get; set; }

        public string img { get; set; }
    }
}
