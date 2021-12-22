using System;
using BabyRecords_Server.Entities;

namespace BabyRecords_Server.features.BabyRecordDiaper.Dto
{
    public class DiaperDto
    {
        public int Id { get; set; }

        public virtual Baby_info_Entity Baby { get; set; }
        //尿布狀況
        public int Diaper { get; set; }

        public DateTime time { get; set; }

        public string remake { get; set; }
    }
}
