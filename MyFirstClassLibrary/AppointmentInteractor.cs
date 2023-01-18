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

        public async Task<Result<bool>> ScheduleAnAppointment(DateTime date, int userId, int medicId)
        {
            if (await _repository.IsAppointmentExists(date, medicId))
            {
                return Result.Fail<bool>("Время уже занято");
            }
            bool appointment = await _repository.SetAppointment(date, userId, medicId);
            return appointment ? Result.Ok(true) : Result.Fail<bool>("Запись не удалась");
        }

        public async Task<Result<List<DateOnly>>> GetFreeTime(Specialization specialization)
        {
            var freeTime = await _repository.GetTimeBySpec(specialization);
            return freeTime.Any() ? Result.Ok(freeTime) : Result.Fail<List<DateOnly>>("Ни одной даты не найдено");
        }
    }
}
