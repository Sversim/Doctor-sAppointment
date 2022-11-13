namespace DataBaseModerator
{
    public class MedicModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Specialization { get; set; }

        public MedicModel (int id, string fullName, int specialization)
        {
            Id = id;
            FullName = fullName;
            Specialization = specialization;
        }
    }
}
