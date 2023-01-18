using Domain;
using Microsoft.AspNetCore.Mvc;
using MyFirstClassLibrary;
using MyFirstSolution.Views;

namespace MyFirstSolution.Controller
{
    public class MedicController
    {
        [ApiController]
        [Route("doctor")]
        public class DoctorController : ControllerBase
        {
            private readonly MedicInteractor _interactor;

            public DoctorController(MedicInteractor interactor)
            {
                _interactor = interactor;
            }


            [HttpPost("create_doctor")]
            public ActionResult<MedicSearchView> AddANewMedic(MedicSearchView medicView)
            {
                if (string.IsNullOrEmpty(medicView.MedicName))
                    return Problem(statusCode: 404, detail: "Не указано имя");

                var medicRes = _interactor.AddANewMedic(medicView.MedicId, medicView.MedicName, medicView.SpecializationId);
                if (medicRes.IsFailure)
                    return Problem(statusCode: 404, detail: medicRes.Error);


                return Ok(new MedicSearchView
                {
                    MedicId = medicRes.Value.Id,
                    MedicName = medicRes.Value.FullName,
                    SpecializationId = medicRes.Value.Specialization.Id,
                });

            }

            [HttpGet("get_doctor")]
            public ActionResult<MedicSearchView> SearchForAMedic(int id)
            {
                var medicrRes = _interactor.SearchForAMedic(id);
                if (medicrRes.IsFailure)
                    return Problem(statusCode: 404, detail: medicrRes.Error);


                return Ok(new MedicSearchView
                {
                    MedicId = medicrRes.Value.Id,
                    MedicName = medicrRes.Value.FullName,
                    SpecializationId = medicrRes.Value.Specialization.Id,
                });
            }

            [HttpGet("get_medics_by_specialization")]
            public ActionResult<List<MedicSearchView>> GetDoctor(SpecializationSearchView specializationView)
            {
                var doctorsRes = _interactor.SearchForAMedic(new Specialization(specializationView.SpecializationId, specializationView.SpecializationName));

                if (doctorsRes.IsFailure)
                    return Problem(statusCode: 404, detail: doctorsRes.Error);

                List<MedicSearchView> doctorSearchViews = new List<MedicSearchView>();

                foreach (var model in doctorsRes.Value)
                    doctorSearchViews.Add(new MedicSearchView
                    {
                        MedicId = model.Id,
                        MedicName = model.FullName,
                        SpecializationId = model.Specialization.Id,
                    });

                return Ok(doctorSearchViews);
            }

            [HttpPost("delete_medic")]
            public ActionResult<bool> DeleteDoctor(int id)
            {
                var doctorRes = _interactor.DeleteMedic(id);
                if (doctorRes.IsFailure)
                    return Problem(statusCode: 404, detail: doctorRes.Error);

                return Ok(doctorRes);
            }

            [HttpGet("get_medic_list")]
            public ActionResult<List<MedicSearchView>> GetDoctorList()
            {
                var medicsRes = _interactor.AllOfMedics();

                if (medicsRes.IsFailure)
                    return Problem(statusCode: 404, detail: medicsRes.Error);

                List<MedicSearchView> medicSearchViews = new List<MedicSearchView>();

                foreach (var model in medicsRes.Value)
                    medicSearchViews.Add(new MedicSearchView
                    {
                        MedicId = model.Id,
                        MedicName = model.FullName,
                        SpecializationId = model.Specialization.Id,
                    });
                return Ok(medicSearchViews);
            }

        }
    }
}
