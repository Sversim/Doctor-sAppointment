using System.Text.Json.Serialization;

namespace MyFirstSolution.Views
{
    public class TimetableSearchView
    {
        [JsonPropertyName("MedicId")]
        public int MedicId { get; set; }

        [JsonPropertyName("Start")]
        public DateTime Start { get; set; }

        [JsonPropertyName("End")]
        public DateTime End { get; set; }

    }
}
