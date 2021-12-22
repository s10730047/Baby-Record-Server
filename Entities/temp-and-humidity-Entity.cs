using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BabyRecords_Server.Entities
{
    public class temp_and_humidity_Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual User_Entity Users { get; set; }
        [ForeignKey("Users")]
        public int UsersID { get; set; }

        public int temp { get; set; }

        public int humidity { get; set; }

        public DateTime Time { get; set; }

    }
}
