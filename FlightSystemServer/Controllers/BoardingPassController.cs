using FlightSystemService.Service;
using Microsoft.AspNetCore.Mvc;

namespace FlightSystemServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardingPassesController : ControllerBase
    {
        private readonly IBoardingPassService _boardingPassService;

        public BoardingPassesController(IBoardingPassService boardingPassService)
        {
            _boardingPassService = boardingPassService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var passes = await _boardingPassService.GetAllBoardingPassesAsync();
            return Ok(passes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pass = await _boardingPassService.GetBoardingPassByIdAsync(id);
            if (pass == null) return NotFound();
            return Ok(pass);
        }
    }
}
