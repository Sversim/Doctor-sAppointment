using System.Text.Json.Serialization;

namespace MyFirstSolution.Views
{
    public class SpecializationSearchView
    {
        [JsonPropertyName("id")]
        public int SpecializationId { get; set; }

        [JsonPropertyName("name")]
        public string SpecializationName { get; set; }
    }
}
