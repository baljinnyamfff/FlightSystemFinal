using FlightSystemDatabase.Model;
using FlightSystemService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics.Eventing.Reader;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FlightSystemServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;
        
        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var flights = await _flightService.GetAllFlightsAsync();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null) return NotFound();
            return Ok(flight);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string newStatus)
        {
            try
            {
                if (!Enum.TryParse<FlightStatus>(newStatus, out var status))
                {
                    return BadRequest($"Invalid status: {newStatus}");
                }

                var result = await _flightService.UpdateFlightStatusAsync(id, status);
                if (!result) return BadRequest("Failed to update status.");
                return Ok("Status updated.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error updating status: {ex.Message}");
            }
        }

        [HttpGet("{id}/seats")]
        public async Task<IActionResult> GetFlightSeats(int id)
        {
            try
            {
                var seats = await _flightService.GetFlightSeatsAsync(id);
                if (seats == null)
                {
                    return Ok(new List<Seat>());
                }
                Console.WriteLine($"seats exists {seats.Count()}");
                return Ok(seats);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving seats: {ex.Message}");
            }
        }
    }
}
