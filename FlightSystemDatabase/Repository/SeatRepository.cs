using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlightSystemDatabase.Model;

namespace FlightSystemDatabase.Repository
{
    public class SeatRepository : ISeatRepository
    {
        private readonly DataBaseContext _context;
        private readonly DbSet<Seat> _dbSet;

        public SeatRepository(DataBaseContext context)
        {
            _context = context;
            _dbSet = context.Seats;
        }

        public async Task<Seat> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<Seat>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task AddAsync(Seat seat) => await _dbSet.AddAsync(seat);

        public void Update(Seat seat) => _dbSet.Update(seat);

        public void Remove(Seat seat) => _dbSet.Remove(seat);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<Seat> GetBySeatNumberAsync(string seatNumber, int flightId)
            => await _dbSet.FirstOrDefaultAsync(s => s.SeatNumber == seatNumber && s.FlightId == flightId);
    }
}