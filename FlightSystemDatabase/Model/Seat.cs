namespace FlightSystemDatabase.Model
{
    public class Seat
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; }
        public int FlightId { get; set; }
        public bool IsAssigned { get; set; }
        public int? PassengerId { get; set; }
        public Flight Flight { get; set; }
        public Passenger Passenger { get; set; }
    }
}