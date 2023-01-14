namespace MyFirstClassLibrary
{
    public class MedicsAppointment
    {
        public DateTime TimeStart;
        public DateTime TimeEnd;
        public int UserId;
        public int MedicId;

        public MedicsAppointment(DateTime timeStart, DateTime timeEnd, int userId, int medicId)
        {
            TimeStart = timeStart;
            TimeEnd = timeEnd;
            UserId = userId;
            MedicId = medicId;
        }
    }
}
