using System;
using BabyRecords_Server.Entities;
namespace BabyRecords_Server.features.BabyRecordHealth.Dto
{
    public class HealthDto
    {
        public int Id { get; set; }

        public virtual Baby_info_Entity Baby { get; set; }
        //健康檢查方法
        public int healthWay { get; set; }

        public DateTime time { get; set; }

        public string remake { get; set; }

    }
}
