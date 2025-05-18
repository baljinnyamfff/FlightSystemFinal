using FlightSystemDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystemService.Service
{
    public interface IPassengerService
    {
        Task<IEnumerable<Passenger>> GetAllPassengersAsync();
        Task<Passenger> GetPassengerByIdAsync(int id);
        Task<Passenger> GetPassengerByPassportAsync(string passportNumber);
    }
}
