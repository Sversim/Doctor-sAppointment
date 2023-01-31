using System.Text.Json.Serialization;

namespace MyFirstSolution.Views
{
    public class MedicSearchView
    {
        [JsonPropertyName("id")]
        public int MedicId { get; set; }

        [JsonPropertyName("name")]
        public string? MedicName { get; set; }

        [JsonPropertyName("speciazlisationId")]
        public int SpecializationId { get; set; }
    }
}
