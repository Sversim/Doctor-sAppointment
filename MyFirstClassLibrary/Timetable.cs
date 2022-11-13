namespace MyFirstClassLibrary
{
    public class Timetable
    {
        public int MedicId;
        public DateTime TimeStart;
        public DateTime TimeEnd;

        public Timetable()
        {
        }

        public Timetable (int medicId, DateTime timeStart, DateTime timeEnd)
        {
            MedicId = medicId;
            TimeStart = timeStart;
            TimeEnd = timeEnd;
        }
    }
}
