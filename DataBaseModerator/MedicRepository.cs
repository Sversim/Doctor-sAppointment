using Domain;
using MyFirstClassLibrary;

namespace DataBaseModerator
{
    internal class MedicRepository : IMedicRepository
    {
        private ApplicationContext _context;
        public MedicRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Medic? AddMedicWithParameters(int Id, string FullName, Specialization Specialization)
        {
            var medic = new MedicModel(Id, FullName, Specialization.Id);
            _context.Medics.Add(medic);
            return medic.ToDomain();
        }

        public Medic? AddMedicWithParameters(int Id, string FullName, int Specialization)
        {
            var medic = new MedicModel(Id, FullName, Id);
            _context.Medics.Add(medic);
            return medic.ToDomain();
        }

        public bool DeleteMedicWithId(int id)
        {
            var uselessMedic = _context.Medics.FirstOrDefault(_context.Medics.FirstOrDefault(m => m.Id == id));
            _context.Medics.Remove(_context.Medics.FirstOrDefault(_context.Medics.FirstOrDefault(m => m.Id == id)));
            return uselessMedic != null;
        }

        public List<Medic>? GetAllMedics()
        {
            List<Medic> medics = new List<Medic>();
            foreach (var medic in _context.Medics.ToList() ?? Enumerable.Empty<MedicModel>())
            {
                medics.Add(medic.ToDomain());
            }
            return medics;
        }

        public List<Medic>? SearchForAMedicsWithSpecialization(Specialization specialization)
        {
            List<Medic> medics = new List<Medic>();
            var searchedScecializationList = _context.Medics.Where(m => m.Id == specialization.Id);
            foreach (var medic in searchedScecializationList ?? Enumerable.Empty<MedicModel>())
            {
                medics.Add(medic.ToDomain());
            }
            return medics;
        }

        public Medic? SearchForAMedicWithId(int id)
        {
            var medic = _context.Medics.FirstOrDefault(_context.Medics.FirstOrDefault(m => m.Id == id));
            return medic != null ? medic.ToDomain() : null;
        }
    }
}
