using Microsoft.AspNetCore.SignalR;
using SignalRPrototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRPrototype.HubConfig
{
    public class ChartHub : Hub
    {
        public async Task Method_BroadcastChartData(List<ChartModel> data) => await Clients.All.SendAsync("event_broadcastchartdata", data);
    }
}
