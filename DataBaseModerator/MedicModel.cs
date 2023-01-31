using System.ComponentModel.DataAnnotations;

namespace DataBaseModerator
{
    public class MedicModel
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Specialization { get; set; }
    }
}
