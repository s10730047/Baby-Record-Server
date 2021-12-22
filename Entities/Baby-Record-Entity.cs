using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyRecords_Server.Entities
{
    public class Baby_Record_Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public virtual Baby_info_Entity Baby { get; set; }
        [ForeignKey("Baby")]
        public int BabyID { get; set; }
        public float height { get; set; }

        public float weight { get; set; }

        public float head { get; set; }

        public int milkingMl { get; set; }
        // 1為尿尿、2大便、3為尿尿加大便、4為乾淨
        public int diaper { get; set; }
        // 1為打針、2為吃藥
        public int healthWay { get; set; }
        // 1為入睡、2為起床
        public int sleep { get; set; }
        // 1為口溫、2為腋溫、3為肛溫
        public int babyTempWay { get; set; }

        public int babyTemp { get; set; }
        // 1為母乳、2為配方奶粉、3為鮮奶
        public int feeding { get; set; }

        public int milkMl { get; set; }

        public int spoon { get; set; }

        public int temp { get; set; }

        public int humidity { get; set; }

        public DateTime time { get; set; }

        public string remark { get; set; }
        /**
        * 1為尿布狀況紀錄、2為成長紀錄、3為健康紀錄、4為擠奶紀錄、5為入睡或起床記錄、6為體溫狀況記錄、7為餵奶紀錄、8為洗澡時間紀錄
        */
        public int recordClass { get; set; }

    }
}
