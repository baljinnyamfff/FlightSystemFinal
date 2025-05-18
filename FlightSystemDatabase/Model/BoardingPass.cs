using System;

namespace FlightSystemDatabase.Model
{
    public class BoardingPass
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public int SeatId { get; set; }
        public int FlightId { get; set; }
        public DateTime IssuedAt { get; set; }
        public Passenger Passenger { get; set; }
        public Seat Seat { get; set; }
        public Flight Flight { get; set; }
    }
}