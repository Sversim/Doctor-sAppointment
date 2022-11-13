using Microsoft.EntityFrameworkCore;

namespace DataBaseModerator
{
    [Keyless]
    public class TimetableModel
    {
        public int MedicId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

        public TimetableModel (int medicId, DateTime timeStart, DateTime timeEnd)
        {
            MedicId = medicId;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
        }
    }
}
