using System;
using BabyRecords_Server.Entities;

namespace BabyRecords_Server.features.BabyRecordGrowing.Dto
{
    public class GrowingDto
    {
        public int Id { get; set; }

        public virtual Baby_info_Entity Baby { get; set; }

        //身高
        public int height { get; set; }

        //體重
        public int weight { get; set; }

        //頭圍
        public int head { get; set; }

        public DateTime time { get; set; }

        public string remake { get; set; }
    }
}
