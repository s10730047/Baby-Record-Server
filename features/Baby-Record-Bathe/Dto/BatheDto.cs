using System;
using BabyRecords_Server.Entities;

namespace BabyRecords_Server.features.BabyRecordBathe.Dto
{
    public class BatheDto
    {

        public int Id { get; set; }

        public virtual Baby_info_Entity Baby { get; set; }

        public DateTime time { get; set; }

        public string remake { get; set; }
    }
}
