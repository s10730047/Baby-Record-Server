using System;
using BabyRecords_Server.Entities;

namespace BabyRecords_Server.features.BabyRecordFeeding.Dto
{
    public class FeedingDto
    {
        public int Id { get; set; }

        public virtual Baby_info_Entity Baby { get; set; }

        //餵食方式
        public int FeedType { get; set; }

        //毫升
        public int milkML { get; set; }

        public DateTime time { get; set; }

        public string remake { get; set; }

    }
}
