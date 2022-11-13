namespace DataBaseModerator
{
    public class AppointmentModel
    {
        public DateTime TimeStart;
        public DateTime TimeEnd;
        public int UserId;
        public int MedicId;

        public AppointmentModel(DateTime timeStart, DateTime timeEnd, int userId, int medicId)
        {
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            UserId = userId;
            MedicId = medicId;
        }
    }
}
