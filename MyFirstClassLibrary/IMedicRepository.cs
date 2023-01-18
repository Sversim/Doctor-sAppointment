using MyFirstClassLibrary;

namespace Domain
{
    public interface IMedicRepository
    {
        Medic? AddMedicWithParameters(int Id, string FullName, Specialization Specialization);
        Medic? AddMedicWithParameters(int Id, string FullName, int Specialization);
        List<Medic>? SearchForAMedicsWithSpecialization(Specialization specialization);
        Medic? SearchForAMedicWithId(int id);
        bool DeleteMedicWithId(int id);
        List<Medic>? GetAllMedics();
    }
}
