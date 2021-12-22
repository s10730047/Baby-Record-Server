using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BabyRecords_Server.Entities
{
    public class Family_Group_Member_Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Family_Group_Entity familyGroup { get; set; }
        [ForeignKey("familyGroup")]
        public int familyGroupID { get; set; }
        public virtual User_Entity users { get; set; }
        [ForeignKey("users")]
        public int usersID { get; set; }
        public int authority { get; set; }

    }
}
