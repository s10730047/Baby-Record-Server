using System;
using BabyRecords_Server.Model;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.BabyRecordTemp.Dto;
using BabyRecords_Server.features.tempandhumidity.Dto;
using System.Linq;
namespace BabyRecords_Server.features.tempandhumidity.Services
{
    public class temp_and_humidityService
    {
        private readonly MyDbContext _MyDbContext;
        public temp_and_humidityService(
           MyDbContext myDbContext
            )
        {
            _MyDbContext = myDbContext;
        }

        //取得溫度列表
        public temp_and_humidity_Entity getTemp(int userId)
        {
            var temp = (from a in _MyDbContext.TempAndHumidity
                        where a.UsersID == userId
                        select a).SingleOrDefault();
            return temp;
        }
  

        //新增溫濕度

        public temp_and_humidity_Entity createTemp(int userId,temp_and_humidityDto value)
        {
            temp_and_humidity_Entity insert = new temp_and_humidity_Entity
            {
                UsersID = userId,
                temp = value.temp,
                humidity = value.humidity,
                Time = value.time   
            };
            _MyDbContext.Add(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }

        //更新即時溫濕度
        public temp_and_humidity_Entity updateTemp(int userId, temp_and_humidityDto value)
        {
            temp_and_humidity_Entity insert = new temp_and_humidity_Entity
            {
                UsersID = userId,
                temp = value.temp,
                humidity = value.humidity,
                Time = value.time
            };
            _MyDbContext.Update(insert);
            _MyDbContext.SaveChanges();
            return insert;
        }
    }
}
