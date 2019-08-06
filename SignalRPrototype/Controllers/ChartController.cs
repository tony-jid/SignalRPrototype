using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRPrototype.DataStorage;
using SignalRPrototype.HubConfig;
using SignalRPrototype.TimerFeatures;

namespace SignalRPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private IHubContext<ChartHub> _hub;

        public ChartController(IHubContext<ChartHub> hub)
        {
            _hub = hub;
        }

        public IActionResult Get()
        {
            string eventName = "transferchartdata";
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync(eventName, DataManager.GetData()));

            return Ok(new { Message = "Request Completed" });
        }
    }
}
