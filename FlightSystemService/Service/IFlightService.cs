using FlightSystemDatabase.Model;
using FlightSystemDatabase.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystemService.Service
{
    public interface IFlightService
    {
        Task<IEnumerable<FlightDto>> GetAllFlightsAsync();
        Task<FlightDto> GetFlightByIdAsync(int id);
        Task<bool> UpdateFlightStatusAsync(int id, FlightStatus newStatus);
        Task<IEnumerable<SeatDto>> GetFlightSeatsAsync(int flightId);
    }
}
