using FlightSystemDatabase.dto;
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
        public async Task AddBoardingPassAsync(BoardingPassDto boardingPassDto)
        {
            try
            {
                var boardingPass = boardingPassDto.ToEntity();

                await _boardingPassRepo.AddAsync(boardingPass);
                await _boardingPassRepo.SaveChangesAsync();
                Console.WriteLine($"BP REPO : successfully added id with {boardingPass.Id}");
            }
            catch
            {
                throw new Exception("cannot add new dto");
            }
        }
        public async Task UpdateBoardingPassAsync(int id, BoardingPassDto boardingPassDto)
        {
            var existingOnes = await _boardingPassRepo.GetAllAsync();
            var existingOne = existingOnes.FirstOrDefault(ex => ex.PassengerId == id);

            if (existingOne == null)
            {
                throw new KeyNotFoundException($"Boarding pass with ID {id} not found. {existingOnes.Count()}");
            }
            existingOne.SeatId = boardingPassDto.SeatId;
            existingOne.FlightId = boardingPassDto.FlightId;
            _boardingPassRepo.Update(existingOne);
            await _boardingPassRepo.SaveChangesAsync();
            return;
        }
    }
}
