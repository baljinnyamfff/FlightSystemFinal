using System.Collections.Generic;

namespace FlightSystemDatabase.Model
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public int FlightId { get; set; }
        public int? SeatId { get; set; }
        public Flight Flight { get; set; }
        public Seat Seat { get; set; }
        public ICollection<BoardingPass> BoardingPasses { get; set; }
    }
}