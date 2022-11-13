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

        public Result<Timetable> GetTimetable(int medicId, DateTime date)
        {
            Timetable? returnedTimetable = _repository.GetMedicsTimetable(medicId, date);
            return returnedTimetable is null ? Result.Fail<Timetable>("Расписание не найдено") : Result.Ok(returnedTimetable);
        }

        public Result<bool> SetTimetable(Timetable timetable)
        {
            return _repository.SetMedicsTimetable(timetable) ? Result.Ok(true) : Result.Fail<bool>("Расписание не установлено");
        }
    }
}
