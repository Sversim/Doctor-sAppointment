using System.Text.Json.Serialization;

namespace MyFirstSolution.Views
{
    public class AppointmentSeacrchView
    {
        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("endTime")]
        public DateTime EndTime { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("medicId")]
        public int MedicId { get; set; }
    }
}
