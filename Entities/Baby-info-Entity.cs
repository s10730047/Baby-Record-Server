using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BabyRecords_Server.Entities
{
    public class Baby_info_Entity
    {
     
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public virtual User_Entity Users { get; set; }
        [ForeignKey("Users")]
        public int UsersID { get; set; }

        public virtual Family_Group_Entity familyGroup { get; set; }
        [ForeignKey("familyGroup")]
        public int familGroupID { get; set; }

        public string babyName { get; set; }

        public DateTime babyBirthday { get; set; }

        public string gender { get; set; }

        public string img { get; set; }

        public virtual ICollection<Baby_Record_Entity> babyrecord { get; set; }
        public virtual ICollection<Baby_Area_Entity> babyArea { get; set; }
        public virtual ICollection<Baby_FaceCover_Entity> babyFaceCover { get; set; }



    }
}
