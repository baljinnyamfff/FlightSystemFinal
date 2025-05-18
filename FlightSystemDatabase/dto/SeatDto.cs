using System.Text.Json.Serialization;

namespace FlightSystemDatabase.dto
{
    public class SeatDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("seatNumber")]
        public string SeatNumber { get; set; } = string.Empty;

        [JsonPropertyName("isAssigned")]
        public bool IsAssigned { get; set; }

        [JsonPropertyName("flightId")]
        public int FlightId { get; set; }

        [JsonPropertyName("passengerId")]
        public int? PassengerId { get; set; }
    }
}