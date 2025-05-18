using System.Text.Json.Serialization;

namespace FlightSystemDatabase.dto
{
    public class PassengerDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("passportNumber")]
        public string PassportNumber { get; set; } = string.Empty;

        [JsonPropertyName("flightId")]
        public int FlightId { get; set; }

        [JsonPropertyName("seatId")]
        public int? SeatId { get; set; }
    }
}