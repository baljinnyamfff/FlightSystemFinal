using System.Threading.Tasks;

namespace FlightSystemService.Service
{
    public interface INotificationService
    {
        Task BroadcastSeatAssignmentAsync(int seatId, int passengerId);
        Task BroadcastFlightStatusAsync(string flightId, string status);
    }
}