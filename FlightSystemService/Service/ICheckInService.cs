using System.Threading.Tasks;

namespace FlightSystemService.Service
{
    public interface ICheckInService
    {
        Task<bool> AssignSeatAsync(int passengerId, int seatId);
        Task<bool> CheckInPassengerAsync(int passengerId, int seatId);
    }
}