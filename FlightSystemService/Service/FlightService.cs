using FlightSystemDatabase.Model;
using FlightSystemDatabase.Repository;
using FlightSystemDatabase.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using FlightSystemService.SignalRHub;

namespace FlightSystemService.Service
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepo;
        private readonly INotificationService _notificationService;

        public FlightService(
            IFlightRepository flightRepo,
            INotificationService notificationService)
        {
            _flightRepo = flightRepo;
            _notificationService = notificationService;
        }

        public async Task<IEnumerable<FlightDto>> GetAllFlightsAsync()
        {
            var flights = await _flightRepo.GetAllAsync();
            return flights.Select(f => f.ToDto());
        }

        public async Task<FlightDto> GetFlightByIdAsync(int id)
        {
            var flight = await _flightRepo.GetByIdAsync(id);
            return flight?.ToDto();
        }

        public async Task<bool> UpdateFlightStatusAsync(int id, FlightStatus newStatus)
        {
            var flight = await _flightRepo.GetByIdAsync(id);
            if (flight == null)
                return false;

            flight.Status = newStatus;
            _flightRepo.Update(flight);
            await _flightRepo.SaveChangesAsync();

            await _notificationService.BroadcastFlightStatusAsync(id, newStatus.ToString());

            return true;
        }

        public async Task<IEnumerable<SeatDto>> GetFlightSeatsAsync(int flightId)
        {
            var flight = await _flightRepo.GetByIdAsync(flightId);
            if (flight == null || flight.Seats == null)
                return new List<SeatDto>();

            return flight.Seats.Select(s => s.ToDto());
        }
    }
}
