using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSystemDatabase.Repository;
using FlightSystemDatabase.Model;

namespace FlightSystemService.Service
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepo;

        public SeatService(ISeatRepository seatRepo)
        {
            _seatRepo = seatRepo;
        }

        public async Task<IEnumerable<Seat>> GetAllSeatsAsync()
        {
             return await _seatRepo.GetAllAsync();
        }

        public async Task<Seat> GetSeatByIdAsync(int id)
        {
            return await _seatRepo.GetByIdAsync(id);
        }

        public async Task<Seat> GetSeatByNumberAsync(string seatNumber, int flightId)
        {
            return await _seatRepo.GetBySeatNumberAsync(seatNumber, flightId);
        }
    }
}
