using System;
using BabyRecords_Server.Entities;

namespace BabyRecords_Server.features.BabyRecordSleep.Dto
{
    public class SleepDto
    {
        public int Id { get; set; }

        public virtual Baby_info_Entity Baby { get; set; }
        //健康檢查方法
        public int sleep { get; set; }

        public DateTime time { get; set; }

        public string remake { get; set; }

    }
}
