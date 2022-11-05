using MyFirstClassLibrary;

namespace Domain
{
    public interface IAppointmentRepository
    {
        bool SetAppointment(DateTime date, int? medicId);
        bool IsAppointmentExists(DateTime date, int? medicId);
        List<DateOnly> GetTimeBySpec(Specialization specialization);
        
    }
}
