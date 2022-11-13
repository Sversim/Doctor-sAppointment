using MyFirstClassLibrary;

namespace Domain
{
    public interface ITimetableRepository
    {
        Timetable? GetMedicsTimetable(int medicId, DateTime date);
        bool SetMedicsTimetable(Timetable timetable);
    }
}
