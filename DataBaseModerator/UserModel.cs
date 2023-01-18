using MyFirstClassLibrary;
using System.ComponentModel.DataAnnotations;

namespace DataBaseModerator
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; } = Role.User;
    }
}
