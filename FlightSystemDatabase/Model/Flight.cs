using System;
using System.Collections.Generic;

namespace FlightSystemDatabase.Model
{
    public enum FlightStatus
    {
        CheckingIn,
        Boarding,
        Departed,
        Delayed,
        Cancelled
    }

    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public FlightStatus Status { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}