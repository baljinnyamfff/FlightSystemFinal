using FlightSystemDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystemService.Service
{
    public interface ISeatService
    {
        Task<IEnumerable<Seat>> GetAllSeatsAsync();
        Task<Seat> GetSeatByIdAsync(int id);
        Task<Seat> GetSeatByNumberAsync(string seatNumber, int flightId);
    }
}
