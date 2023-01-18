using MyFirstClassLibrary;
using System.Text.Json.Serialization;

namespace MyFirstSolution.Views
{
    public class UserSearchView
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("userName")]
        public string Name { get; set; }

        [JsonPropertyName("login")]
        public string Login { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("role")]
        public Role UserRole { get; set; }
    }
}
