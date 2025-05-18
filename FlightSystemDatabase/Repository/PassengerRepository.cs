using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlightSystemDatabase.Model;

namespace FlightSystemDatabase.Repository
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly DataBaseContext _context;
        private readonly DbSet<Passenger> _dbSet;

        public PassengerRepository(DataBaseContext context)
        {
            _context = context;
            _dbSet = context.Passengers;
        }

        public async Task<Passenger> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<Passenger>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task AddAsync(Passenger passenger) => await _dbSet.AddAsync(passenger);

        public void Update(Passenger passenger) => _dbSet.Update(passenger);

        public void Remove(Passenger passenger) => _dbSet.Remove(passenger);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<Passenger> GetByPassportNumberAsync(string passportNumber)
            => await _dbSet.FirstOrDefaultAsync(p => p.PassportNumber == passportNumber);
    }
}