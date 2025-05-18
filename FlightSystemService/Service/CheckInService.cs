using System.Threading.Tasks;
using FlightSystemDatabase.Model;
using FlightSystemDatabase.Repository;

namespace FlightSystemService.Service;

public class CheckInService : ICheckInService
{
    private readonly IPassengerRepository _passengerRepo;
    private readonly ISeatRepository _seatRepo;
    private readonly IBoardingPassRepository _boardingPassRepo;

    public CheckInService(
        IPassengerRepository passengerRepo,
        ISeatRepository seatRepo,
        IBoardingPassRepository boardingPassRepo)
    {
        _passengerRepo = passengerRepo;
        _seatRepo = seatRepo;
        _boardingPassRepo = boardingPassRepo;
    }

    public async Task<bool> AssignSeatAsync(int passengerId, int seatId)
    {
        var seat = await _seatRepo.GetByIdAsync(seatId);
        if (seat == null || seat.IsAssigned)
            return false;

        var passenger = await _passengerRepo.GetByIdAsync(passengerId);
        if (passenger == null)
            return false;

        seat.IsAssigned = true;
        seat.PassengerId = passengerId;
        passenger.SeatId = seatId;

        _seatRepo.Update(seat);
        _passengerRepo.Update(passenger);
        await _seatRepo.SaveChangesAsync();
        await _passengerRepo.SaveChangesAsync();

        return true;
    }

    public async Task<bool> CheckInPassengerAsync(int passengerId, int seatId)
    {
        var assigned = await AssignSeatAsync(passengerId, seatId);
        if (!assigned)
            return false;

        var boardingPass = new BoardingPass
        {
            PassengerId = passengerId,
            SeatId = seatId,
            FlightId = (await _passengerRepo.GetByIdAsync(passengerId)).FlightId,
            IssuedAt = System.DateTime.UtcNow
        };

        await _boardingPassRepo.AddAsync(boardingPass);
        await _boardingPassRepo.SaveChangesAsync();

        return true;
    }
}