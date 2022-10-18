using MyFirstClassLibrary;

namespace Domain
{
    public interface IAppointmentRepository
    {
        bool SetAppointment(DateTime date, int? medicId);
        List<MedicsAppointment>? GetFreeTimeBySpec(Specialization specialization);
        
    }
}
