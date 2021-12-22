using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BabyRecords_Server.Entities
{
    public class Family_Group_Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string familyGroupName { get; set; }

        public virtual ICollection<Baby_info_Entity> Baby { get; set; }

        public virtual ICollection<Family_Group_Member_Entity> Family_Group_Member { get; set; }
    }
}
