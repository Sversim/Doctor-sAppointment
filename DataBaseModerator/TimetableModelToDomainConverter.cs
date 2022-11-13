using MyFirstClassLibrary;

namespace DataBaseModerator
{
    public static class TimetableModelToDomainConverter
    {
        public static Timetable? ToDomain(this TimetableModel model)
        {
            return new Timetable(model.MedicId, model.TimeStart, model.TimeEnd);
        }
    }
}
