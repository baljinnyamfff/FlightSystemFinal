using System.Collections.Generic;
using System.Threading.Tasks;
using FlightSystemDatabase.Model;

namespace FlightSystemDatabase.Repository
{
    public interface IFlightRepository
    {
        Task<Flight> GetByIdAsync(int id);
        Task<IEnumerable<Flight>> GetAllAsync();
        Task AddAsync(Flight flight);
        void Update(Flight flight);
        void Remove(Flight flight);
        Task SaveChangesAsync();
        Task<Flight> GetByFlightNumberAsync(string flightNumber);
        Task<IEnumerable<Flight>> GetByStatusAsync(FlightStatus status);
    }
}