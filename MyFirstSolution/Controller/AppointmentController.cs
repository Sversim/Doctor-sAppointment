using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirstClassLibrary;
using MyFirstSolution.Views;

namespace MyFirstSolution.Controller
{
    public class AppointmentController : ControllerBase
    {
        public readonly AppointmentInteractor _interactor;

        public AppointmentController(AppointmentInteractor interactor)
        {
            _interactor = interactor;
        }

        [Authorize]
        [HttpPost("save_medic_appointment")]
        public async Task<ActionResult<bool>> SaveAppointment(DateTime startTime, UserSearchView userView, MedicSearchView medicView)
        {
            var user = new User(userView.Id, userView.PhoneNumber, userView.Name, userView.Login, userView.Password, userView.UserRole);
            var medic = new Medic(medicView.MedicId, medicView.MedicName, medicView.SpecializationId);

            var res = await _interactor.ScheduleAnAppointment(startTime, user.Id, medic.Id);

            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);

            return Ok(res);
        }

        [Authorize]
        [HttpPost("get_free_time_to_appointment")]
        public async Task<ActionResult<List<DateOnly>>> GetFreeAppointmentDateList(SpecializationSearchView specializationView)
        {
            var specialization = new Specialization(specializationView.SpecializationId, specializationView.SpecializationName);

            var res = await _interactor.GetFreeTime(specialization);

            if (res.IsFailure)
                return Problem(statusCode: 404, detail: res.Error);

            return Ok(res.Value);
        }
    }
}
