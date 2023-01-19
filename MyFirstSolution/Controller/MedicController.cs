using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFirstClassLibrary;
using MyFirstSolution.Views;

namespace MyFirstSolution.Controller
{
    [ApiController]
    [Route("medic")]
    public class MedicController : ControllerBase
    {
        private readonly MedicInteractor _interactor;

        public MedicController(MedicInteractor interactor)
        {
            _interactor = interactor;
        }

        [Authorize]
        [HttpPost("create_medic")]
        public async Task<ActionResult<MedicSearchView>> AddANewMedic(int MedicId, string MedicName, int SpecializationId)
        {
            if (string.IsNullOrEmpty(MedicName))
                return Problem(statusCode: 404, detail: "Не указано имя");

            var medicRes = await _interactor.AddANewMedic(MedicId, MedicName, SpecializationId);
            if (medicRes.IsFailure)
                return Problem(statusCode: 404, detail: medicRes.Error);


            return Ok(new MedicSearchView
            {
                MedicId = medicRes.Value.Id,
                MedicName = medicRes.Value.FullName,
                SpecializationId = medicRes.Value.Specialization.Id,
            });

        }

        [HttpGet("get_medic")]
        public async Task<ActionResult<MedicSearchView>> SearchForAMedic(int id)
        {
            var medicrRes = await _interactor.SearchForAMedic(id);
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
        public async Task<ActionResult<List<MedicSearchView>>> GetMedic(SpecializationSearchView specializationView)
        {
            var medicsRes = await _interactor.SearchForAMedic(new Specialization(specializationView.SpecializationId, specializationView.SpecializationName));

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


        [Authorize]
        [HttpPost("delete_medic")]
        public async Task<ActionResult<bool>> DeleteMedic(int id)
        {
            var medicRes = await _interactor.DeleteMedic(id);
            if (medicRes.IsFailure)
                return Problem(statusCode: 404, detail: medicRes.Error);

            return Ok(medicRes);
        }

        [HttpGet("get_medic_list")]
        public async Task<ActionResult<List<MedicSearchView>>> GetMedicList()
        {
            var medicsRes = await _interactor.AllOfMedics();

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
