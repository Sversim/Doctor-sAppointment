using MyFirstClassLibrary;

namespace Domain
{
    public class TimetableInteractor
    {
        private readonly ITimetableRepository _repository;

        public TimetableInteractor(ITimetableRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Timetable>> GetTimetable(int medicId, DateTime date)
        {
            Timetable? returnedTimetable = await _repository.GetMedicsTimetable(medicId, date);
            return returnedTimetable is null ? Result.Fail<Timetable>("Расписание не найдено") : Result.Ok(returnedTimetable);
        }

        public async Task<Result<bool>> SetTimetable(Timetable timetable)
        {
            return await _repository.SetMedicsTimetable(timetable) ? Result.Ok(true) : Result.Fail<bool>("Расписание не установлено");
        }
    }
}
