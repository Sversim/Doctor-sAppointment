using MyFirstClassLibrary;

namespace Domain
{
    public interface ISpecializationRepository
    {
        public Specialization GetSpecializationById(int id); 
    }
}
