using MyFirstClassLibrary;

namespace Domain
{
    public interface ITimetableRepository
    {
        Task<Timetable?> GetMedicsTimetable(int medicId, DateTime date);
        Task<bool> SetMedicsTimetable(Timetable timetable);
    }
}
