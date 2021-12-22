using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BabyRecords_Server.Entities;
using BabyRecords_Server.features.tempandhumidity.Dto;
using BabyRecords_Server.features.tempandhumidity.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyRecords_Server.features.tempandhumidity
{
    [Route("api/[controller]")]
    public class temp_and_humidityController : Controller
    {
        private readonly temp_and_humidityService _temp_and_humidityService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public temp_and_humidityController(
            temp_and_humidityService Temp_and_humidityService,
            IHttpContextAccessor httpContextAccessor

            )
        {
            _temp_and_humidityService = Temp_and_humidityService;
            _httpContextAccessor = httpContextAccessor;
        }

        // 取得溫濕度列表
        [HttpGet("{userId}")]
        public ActionResult<temp_and_humidity_Entity> getTempAndHumidity(int userId)
        {
            var Result = _temp_and_humidityService.getTemp(userId);
            return CreatedAtAction(nameof(getTempAndHumidity), new { id = Result.Id }, Result);

        }

        // 新增溫濕度
        [HttpPost]
        public ActionResult<temp_and_humidity_Entity> addTempAndHumidity([FromBody] temp_and_humidityDto value)
        {
            var userID = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _temp_and_humidityService.createTemp(Convert.ToInt16(userID), value);
            return CreatedAtAction(nameof(addTempAndHumidity), new { id = result.Id }, result);
        }

        // 更新溫濕度
        [HttpPut("{userId}")]
        public ActionResult<temp_and_humidity_Entity> RenewTempAndHumidity(int userId, [FromBody] temp_and_humidityDto value)
        {
            var result = _temp_and_humidityService.updateTemp(userId, value);
            return CreatedAtAction(nameof(RenewTempAndHumidity), new { id = result.Id }, result);
        }
    }
}
