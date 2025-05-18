using System.Collections.Generic;
using System.Threading.Tasks;
using FlightSystemDatabase.Model;

namespace FlightSystemDatabase.Repository
{
    public interface ISeatRepository
    {
        Task<Seat> GetByIdAsync(int id);
        Task<IEnumerable<Seat>> GetAllAsync();
        Task AddAsync(Seat seat);
        void Update(Seat seat);
        void Remove(Seat seat);
        Task SaveChangesAsync();

        // Custom
        Task<Seat> GetBySeatNumberAsync(string seatNumber, int flightId);
    }
}