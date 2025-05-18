using FlightSystemDatabase.Model;
using FlightSystemDatabase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystemService.Service
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepo;

        public PassengerService(IPassengerRepository passengerRepo)
        {
            _passengerRepo = passengerRepo;
        }

        public async Task<IEnumerable<Passenger>> GetAllPassengersAsync()
        {
            return await _passengerRepo.GetAllAsync();
        }

        public async Task<Passenger> GetPassengerByIdAsync(int id)
        {
            return await _passengerRepo.GetByIdAsync(id);
        }

        public async Task<Passenger> GetPassengerByPassportAsync(string passportNumber)
        {
            return await _passengerRepo.GetByPassportNumberAsync(passportNumber);
        }
    }
}
