namespace MyFirstClassLibrary
{
    public class Medic
    {
        public int Id;
        public string FullName;
        public Specialization Specialization;

        public Medic(int id, string fullName, int specialization)
        {
            Id = id;
            FullName = fullName;
            Specialization = new Specialization(specialization);
            // TODO Здесь должен быть перевод int в существующую в таблице специализацию, видимо
        }

        public Medic(int id, string fullName, Specialization specialization)
        {
            Id = id;
            FullName = fullName;
            Specialization = specialization;
        }
    }
}
