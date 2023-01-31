using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DataBaseModerator
{
    [Keyless]
    public class AppointmentModel
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int UserId { get; set; }
        public int MedicId { get; set; }
    }
}
