using Domain;
using MyFirstClassLibrary;

namespace DataBaseModerator
{
    public static class MedicModelToDomainConverter
    {
        public static Medic? ToDomain(this MedicModel model)
        {
            return new Medic(model.Id, model.FullName, model.Specialization);
        }
    }
}
