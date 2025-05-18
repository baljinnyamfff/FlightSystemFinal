using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlightSystemDatabase.Model;

namespace FlightSystemDatabase.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly DataBaseContext _context;
        private readonly DbSet<Flight> _dbSet;

        public FlightRepository(DataBaseContext context)
        {
            _context = context;
            _dbSet = context.Flights;
        }

        public async Task<Flight> GetByIdAsync(int id) =>
            await _dbSet
                .Include(f => f.Seats)
                .FirstOrDefaultAsync(f => f.Id == id);

        public async Task<IEnumerable<Flight>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task AddAsync(Flight flight) => await _dbSet.AddAsync(flight);

        public void Update(Flight flight) => _dbSet.Update(flight);

        public void Remove(Flight flight) => _dbSet.Remove(flight);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<Flight> GetByFlightNumberAsync(string flightNumber)
            => await _dbSet.FirstOrDefaultAsync(f => f.FlightNumber == flightNumber);

        public async Task<IEnumerable<Flight>> GetByStatusAsync(FlightStatus status)
            => await _dbSet.Where(f => f.Status == status).ToListAsync();
    }
}