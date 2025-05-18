using System.Collections.Generic;
using System.Threading.Tasks;
using FlightSystemDatabase.Model;

namespace FlightSystemDatabase.Repository
{
    public interface IPassengerRepository
    {
        Task<Passenger> GetByIdAsync(int id);
        Task<IEnumerable<Passenger>> GetAllAsync();
        Task AddAsync(Passenger passenger);
        void Update(Passenger passenger);
        void Remove(Passenger passenger);
        Task SaveChangesAsync();

        // Custom
        Task<Passenger> GetByPassportNumberAsync(string passportNumber);
    }
}