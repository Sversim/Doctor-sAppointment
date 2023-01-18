using Domain;
using MyFirstClassLibrary;

namespace DataBaseModerator
{
    public class MedicRepository : IMedicRepository
    {
        private ApplicationContext _context;
        public MedicRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Medic> AddMedicWithParameters(int Id, string FullName, Specialization Specialization)
        {
            var medic = new MedicModel{
                Id = Id, 
                FullName = FullName,
                Specialization = Specialization.Id
            };
            _context.Medics.Add(medic);
            _context.SaveChanges();
            return medic.ToDomain();
        }

        public async Task<Medic> AddMedicWithParameters(int Id, string FullName, int Specialization)
        {
            var medic = new MedicModel
            {
                Id = Id,
                FullName = FullName,
                Specialization = Specialization
            };
            _context.Medics.Add(medic);
            _context.SaveChanges();
            return medic.ToDomain();
        }

        public async Task<bool> DeleteMedicWithId(int id)
        {
            var uselessMedic = _context.Medics.FirstOrDefault(_context.Medics.FirstOrDefault(m => m.Id == id));
            _context.Medics.Remove(_context.Medics.FirstOrDefault(_context.Medics.FirstOrDefault(m => m.Id == id)));
            return uselessMedic != null;
        }

        public async Task<List<Medic>?> GetAllMedics()
        {
            List<Medic> medics = new List<Medic>();
            foreach (var medic in _context.Medics.ToList() ?? Enumerable.Empty<MedicModel>())
            {
                medics.Add(medic.ToDomain());
            }
            return medics;
        }

        public async Task<List<Medic>?> SearchForAMedicsWithSpecialization(Specialization specialization)
        {
            List<Medic> medics = new List<Medic>();
            var searchedScecializationList = _context.Medics.Where(m => m.Id == specialization.Id);
            foreach (var medic in searchedScecializationList ?? Enumerable.Empty<MedicModel>())
            {
                medics.Add(medic.ToDomain());
            }
            return medics;
        }

        public async Task<Medic?> SearchForAMedicWithId(int id)
        {
            var medic = _context.Medics.FirstOrDefault(_context.Medics.FirstOrDefault(m => m.Id == id));
            return medic != null ? medic.ToDomain() : null;
        }
    }
}
