using System.Text.Json.Serialization;

namespace FlightSystemDatabase.dto
{
    public class BoardingPassDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("passengerId")]
        public int PassengerId { get; set; }

        [JsonPropertyName("seatId")]
        public int? SeatId { get; set; }

        [JsonPropertyName("flightId")]
        public int FlightId { get; set; }

        [JsonPropertyName("issuedAt")]
        public DateTime IssuedAt { get; set; }
    }
}