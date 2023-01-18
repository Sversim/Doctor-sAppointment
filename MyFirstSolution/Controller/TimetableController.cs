using Domain;
using Microsoft.AspNetCore.Mvc;
using MyFirstClassLibrary;
using MyFirstSolution.Views;

namespace MyFirstSolution.Controller
{
    public class TimetableController : ControllerBase
    {
        private readonly TimetableInteractor _interactor;

        public TimetableController(TimetableInteractor interactor)
        {
            _interactor = interactor;
        }

        [HttpPost("set_tt")]
        public ActionResult<bool> AddTimetable(TimetableSearchView timetableView)
        {
            var timetableRes = _interactor.SetTimetable(new Timetable(timetableView.MedicId, timetableView.Start, timetableView.End));

            if (timetableRes.IsFailure)
                return Problem(statusCode: 404, detail: timetableRes.Error);

            return Ok(timetableRes);
        }

        [HttpGet("get_tt")]
        public ActionResult<TimetableSearchView> GetMedicTimetableByDate(MedicSearchView medicView, DateTime date)
        {
            var medic = new Medic(medicView.MedicId, medicView.MedicName, medicView.SpecializationId);

            var timetableRes = _interactor.GetTimetable(medic.Id, date);

            if (timetableRes.IsFailure)
                return Problem(statusCode: 404, detail: timetableRes.Error);

            return Ok(new TimetableSearchView
            {
                MedicId = timetableRes.Value.MedicId,
                Start = timetableRes.Value.TimeStart,
                End = timetableRes.Value.TimeEnd,
            });
        }
    }
}
