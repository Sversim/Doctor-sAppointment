using System.Text.Json.Serialization;

namespace MyFirstSolution.Views
{
    public class UserSearchView
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        [JsonPropertyName("login")]
        public string Login { get; set; }
    }
}
