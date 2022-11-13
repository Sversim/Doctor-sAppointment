using MyFirstClassLibrary;

namespace DataBaseModerator
{
    public static class AppointmentModelToDomainConverter
    {
        public static MedicsAppointment? ToDomain(this AppointmentModel model)
        {
            return new MedicsAppointment(model.TimeStart, model.TimeEnd, model.UserId, model.MedicId);
        }
    }
}
