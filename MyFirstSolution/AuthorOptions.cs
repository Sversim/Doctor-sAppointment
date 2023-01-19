using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyFirstSolution
{
    public class AuthorOptions
    {
        public const string ISSUER = "MedicServer";
        public const string AUDIENCE = "MedicClient";
        const string KEY = "the_meaning_of_life_is_42";   // ключ для шифрации
        public const int LIFETIME = 3;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
