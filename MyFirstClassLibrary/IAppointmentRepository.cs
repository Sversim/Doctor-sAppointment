using MyFirstClassLibrary;

namespace Domain
{
    public interface IAppointmentRepository
    {
        Task<bool> SetAppointment(DateTime date, int userId, int medicId);
        Task<bool> IsAppointmentExists(DateTime date, int? medicId);
        Task<List<DateOnly>> GetTimeBySpec(Specialization specialization);
        
    }
}
