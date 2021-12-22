using System;
using BabyRecords_Server.Entities;
namespace BabyRecords_Server.features.BabyRecordMilking.Dto
{
    public class MilkingDto
    {
        public int Id { get; set; }

        public virtual Baby_info_Entity Baby { get; set; }

        public int milkingML { get; set; }

        public DateTime time { get; set; }

        public string remake { get; set; }
    }
}
