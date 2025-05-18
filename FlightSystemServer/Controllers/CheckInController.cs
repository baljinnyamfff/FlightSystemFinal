using FlightSystemService.Service;
using Microsoft.AspNetCore.Mvc;

namespace FlightSystemServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckInController : ControllerBase
    {
        private readonly ICheckInService _checkInService;
        private readonly IPassengerService _passengerService;

        public CheckInController(ICheckInService checkInService, IPassengerService passengerService)
        {
            _checkInService = checkInService;
            _passengerService = passengerService;
        }

        [HttpPost("assign-seat")]
        public async Task<IActionResult> AssignSeat(int passengerId, int seatId)
        {
            var result = await _checkInService.AssignSeatAsync(passengerId, seatId);
            if (!result) return BadRequest("Seat assignment failed.");

            var socketWorker = HttpContext.RequestServices.GetRequiredService<SocketWorker>();
            socketWorker.BroadcastToAgents($"Seat {seatId} assigned to passenger {passengerId}");

            return Ok("Seat assigned successfully.");
        }

        [HttpPost("check-in")]
        public async Task<IActionResult> CheckIn(int passengerId, int seatId)
        {
            var result = await _checkInService.CheckInPassengerAsync(passengerId, seatId);
            if (!result) return BadRequest("Check-in failed.");
            return Ok("Check-in successful.");
        }

        [HttpGet("search-passenger")]
        public async Task<IActionResult> SearchPassenger(string passportNumber)
        {
            var passenger = await _passengerService.GetPassengerByPassportAsync(passportNumber);
            if (passenger == null) return NotFound("Passenger not found.");
            return Ok(passenger);
        }
    }
}
