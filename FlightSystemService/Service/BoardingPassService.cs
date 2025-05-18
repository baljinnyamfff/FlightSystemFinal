using FlightSystemDatabase.Model;
using FlightSystemDatabase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystemService.Service
{
    public class BoardingPassService : IBoardingPassService
    {
        private readonly IBoardingPassRepository _boardingPassRepo;

        public BoardingPassService(IBoardingPassRepository boardingPassRepo)
        {
            _boardingPassRepo = boardingPassRepo;
        }

        public async Task<IEnumerable<BoardingPass>> GetAllBoardingPassesAsync()
        {
             return await _boardingPassRepo.GetAllAsync();
        }
           

        public async Task<BoardingPass> GetBoardingPassByIdAsync(int id)
        {
             return await _boardingPassRepo.GetByIdAsync(id);
        }
           

        public async Task<BoardingPass> GetBoardingPassByPassengerIdAsync(int passengerId)
        {
            return await _boardingPassRepo.GetByPassengerIdAsync(passengerId);
        }
    }
}
