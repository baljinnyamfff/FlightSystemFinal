using FlightSystemService.Service;
using Microsoft.AspNetCore.Mvc;

namespace FlightSystemServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var seats = await _seatService.GetAllSeatsAsync();
            return Ok(seats);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var seat = await _seatService.GetSeatByIdAsync(id);
            if (seat == null) return NotFound();
            return Ok(seat);
        }
    }
}
