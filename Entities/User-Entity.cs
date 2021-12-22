using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BabyRecords_Server.Entities
{
    public class User_Entity
    {
    
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string name { get; set; }

        public string account { get; set; }

        public string password { get; set; }

        public string salt { get; set; }

        public string email { get; set; }

        public virtual ICollection<Baby_info_Entity> BabyInfo { get; set; }
        public virtual ICollection<Family_Group_Member_Entity> Family_Group_Member { get; set; }
        public virtual ICollection<temp_and_humidity_Entity> Temp_And_Humidities { get; set; }

    }
}
