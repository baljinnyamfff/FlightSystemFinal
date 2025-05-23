using Microsoft.AspNetCore.SignalR;
using FlightSystemService.SignalRHub;
using FlightSystemDatabase.Model;

namespace FlightSystemService.Service
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<FlightHub> _hubContext;
        private readonly ISocketWorker _socketWorker;

        public NotificationService(
            IHubContext<FlightHub> hubContext,
            ISocketWorker socketWorker)
        {
            _hubContext = hubContext;
            _socketWorker = socketWorker;
        }

        public async Task BroadcastSeatAssignmentAsync(int seatId, int passengerId)
        {
            _socketWorker.BroadcastToAgents($"SEAT_ASSIGNED|{seatId}\n");
        }
        public async Task BroadcastFlightStatusSocketAsync(string fNumber, string status)
        {
            _socketWorker.BroadcastToAgents($"FLIGHT_STATUS|{fNumber}|{status}\n");
        }
        public async Task BroadcastFlightStatusAsync(string fNumber, string status)
        {
            // Broadcast to display screens via SignalR
            await _hubContext.Clients.All.SendAsync("ReceiveFlightStatus", fNumber, status);
        }
    }
}