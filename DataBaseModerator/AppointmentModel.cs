using Microsoft.EntityFrameworkCore;

namespace DataBaseModerator
{
    [Keyless]
    public class AppointmentModel
    {
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int UserId { get; set; }
        public int MedicId { get; set; }

        public AppointmentModel(DateTime timeStart, DateTime timeEnd, int userId, int medicId)
        {
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            UserId = userId;
            MedicId = medicId;
        }
    }
}
