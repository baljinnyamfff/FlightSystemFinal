using FlightSystemService.Service;
using Microsoft.AspNetCore.Mvc;

namespace FlightSystemServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassengersController : ControllerBase
    {
        private readonly IPassengerService _passengerService;

        public PassengersController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var passengers = await _passengerService.GetAllPassengersAsync();
            return Ok(passengers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var passenger = await _passengerService.GetPassengerByIdAsync(id);
            if (passenger == null) return NotFound();
            return Ok(passenger);
        }
    }
}
