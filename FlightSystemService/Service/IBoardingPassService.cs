using FlightSystemDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSystemDatabase.dto;

namespace FlightSystemService.Service
{
    public interface IBoardingPassService
    {
        Task<IEnumerable<BoardingPass>> GetAllBoardingPassesAsync();
        Task<BoardingPass> GetBoardingPassByIdAsync(int id);
        Task<BoardingPass> GetBoardingPassByPassengerIdAsync(int passengerId);
        Task AddBoardingPassAsync(BoardingPassDto boardingPass);
        Task UpdateBoardingPassAsync(int id, BoardingPassDto newBoardingPass);
    }
}
