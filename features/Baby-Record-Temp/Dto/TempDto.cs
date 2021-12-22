using System;
using BabyRecords_Server.Entities;

namespace BabyRecords_Server.features.BabyRecordTemp.Dto
{
    public class TempDto
    {
        public int Id { get; set; }

        public virtual Baby_info_Entity Baby { get; set; }

        public int HowToGetTemp { get; set; }

        public int temp { get; set; }

        public DateTime time { get; set; }

        public string remake { get; set; }
    }
}
