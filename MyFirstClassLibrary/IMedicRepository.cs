using MyFirstClassLibrary;

namespace Domain
{
    public interface IMedicRepository
    {
        Medic? AddMedicWithParameters(int Id, string FullName, Specialization Specialization);
        List<Medic>? SearchForAMedicsWithSpecialization(Specialization specialization);
        Medic? SearchForAMedicWithId(int id);
        bool DeleteMedicWithId(int id);
        List<Medic>? GetAllMedics();
    }
}
