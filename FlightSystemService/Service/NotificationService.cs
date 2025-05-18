using Microsoft.AspNetCore.SignalR;
using FlightSystemService.SignalRHub;

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
            // Broadcast to agents via socket
            _socketWorker.BroadcastToAgents($"Seat {seatId} assigned to passenger {passengerId}");
        }

        public async Task BroadcastFlightStatusAsync(int flightId, string status)
        {
            // Broadcast to display screens via SignalR
            await _hubContext.Clients.All.SendAsync("ReceiveFlightStatus", flightId, status);
        }
    }
}