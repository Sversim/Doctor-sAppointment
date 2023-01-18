using MyFirstClassLibrary;

namespace Domain
{
    public interface IMedicRepository
    {
        Task<Medic?> AddMedicWithParameters(int Id, string FullName, Specialization Specialization);
        Task<Medic?> AddMedicWithParameters(int Id, string FullName, int Specialization);
        Task<List<Medic>?> SearchForAMedicsWithSpecialization(Specialization specialization);
        Task<Medic?> SearchForAMedicWithId(int id);
        Task<bool> DeleteMedicWithId(int id);
        Task<List<Medic>?> GetAllMedics();
    }
}
