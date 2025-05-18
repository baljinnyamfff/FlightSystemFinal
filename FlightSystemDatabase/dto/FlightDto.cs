using System.Text.Json.Serialization;

namespace FlightSystemDatabase.dto
{
    public class FlightDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("flightNumber")]
        public string FlightNumber { get; set; } = string.Empty;

        [JsonPropertyName("destination")]
        public string Destination { get; set; } = string.Empty;

        [JsonPropertyName("departureTime")]
        public DateTime DepartureTime { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        public string Display => $"{FlightNumber} - {Destination} ({Status})";
    }
}