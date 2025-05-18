using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace FlightSystemService.SignalRHub
{
    public class FlightHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"Client disconnected: {Context.ConnectionId}, Reason: {exception?.Message}");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendFlightStatus(int flightId, string status)
        {
            Console.WriteLine($"Broadcasting status update in flightHub.cs: {flightId} -> {status}");
            await Clients.All.SendAsync("ReceiveFlightStatus", flightId, status);
        }
    }
}
