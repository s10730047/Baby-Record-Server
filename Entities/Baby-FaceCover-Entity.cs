using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BabyRecords_Server.Entities
{
    public class Baby_FaceCover_Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Baby_info_Entity Baby { get; set; }
        [ForeignKey("Baby")]
        public int BabyID { get; set; }

        public string Event { get; set; }

        public string EventImg { get; set; }

        public DateTime time { get; set; }


    }
}
