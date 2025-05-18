using System.Collections.Generic;
using System.Threading.Tasks;
using FlightSystemDatabase.Model;

namespace FlightSystemDatabase.Repository
{
    public interface IBoardingPassRepository
    {
        Task<BoardingPass> GetByIdAsync(int id);
        Task<IEnumerable<BoardingPass>> GetAllAsync();
        Task AddAsync(BoardingPass boardingPass);
        void Update(BoardingPass boardingPass);
        void Remove(BoardingPass boardingPass);
        Task SaveChangesAsync();

        // Custom
        Task<BoardingPass> GetByPassengerIdAsync(int passengerId);
    }
}