using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlightSystemDatabase.Model;

namespace FlightSystemDatabase.Repository
{
    public class BoardingPassRepository : IBoardingPassRepository
    {
        private readonly DataBaseContext _context;
        private readonly DbSet<BoardingPass> _dbSet;

        public BoardingPassRepository(DataBaseContext context)
        {
            _context = context;
            _dbSet = context.BoardingPasses;
        }

        public async Task<BoardingPass> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<BoardingPass>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task AddAsync(BoardingPass boardingPass) => await _dbSet.AddAsync(boardingPass);

        public void Update(BoardingPass boardingPass) => _dbSet.Update(boardingPass);

        public void Remove(BoardingPass boardingPass) => _dbSet.Remove(boardingPass);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<BoardingPass> GetByPassengerIdAsync(int passengerId)
            => await _dbSet.FirstOrDefaultAsync(bp => bp.PassengerId == passengerId);
    }
}