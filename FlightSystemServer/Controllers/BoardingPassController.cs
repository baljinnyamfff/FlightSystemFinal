using FlightSystemDatabase.dto;
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
        [HttpPost]
        public async Task<IActionResult> Add(BoardingPassDto boardingPassDto)
        {
            try
            {
                await _boardingPassService.AddBoardingPassAsync(boardingPassDto);
                Console.Write($"{boardingPassDto.IssuedAt} {boardingPassDto.PassengerId}");
                return Ok("successfully add BP");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BoardingPassDto boardingPassDto)
        {
            try
            {
                await _boardingPassService.UpdateBoardingPassAsync(id, boardingPassDto);
                Console.WriteLine($"int the controller got the UPDATING bpdto{boardingPassDto.Id}");
                return Ok("successfully updated");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
