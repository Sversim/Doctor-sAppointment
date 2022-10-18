using MyFirstClassLibrary;

namespace Domain
{
    public class AppointmentInteractor
    {
        private readonly IAppointmentRepository _repository;
        public AppointmentInteractor(IAppointmentRepository repository)
        {
            _repository = repository;
        }

        public Result<bool> ScheduleAnAppointment(DateTime date, int? medicId=null)
        {
            bool appointment = _repository.SetAppointment(date, medicId);
            return appointment ? Result.Ok(true) : Result.Fail<bool>("Запись не удалась");
        }

        public Result<List<MedicsAppointment>> GetFreeTime(Specialization specialization)
        {
            List<MedicsAppointment>? freeTime = _repository.GetFreeTimeBySpec(specialization);
            return freeTime?.Any() ?? false ? Result.Ok(freeTime) : Result.Fail<List<MedicsAppointment>>("Ни одной даты не найдено");
        }
    }
}
