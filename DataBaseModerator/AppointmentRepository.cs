using Domain;
using Microsoft.EntityFrameworkCore;
using MyFirstClassLibrary;

namespace DataBaseModerator
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private ApplicationContext _context;
        public AppointmentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<DateOnly>> GetTimeBySpec(Specialization specialization)
        {
            var fullAppointment = _context.Appointments
                .Join(_context.Medics,
                    app => app.MedicId,
                    med => med.Specialization,
                    (app, med) => new { app.TimeStart, med.Specialization, med.Id } )
                .Where(med => med.Specialization == specialization.Id);

            List<DateOnly> dates = new List<DateOnly>();
            for (var day = DateOnly.FromDateTime(DateTime.Now); 
                day <= DateOnly.FromDateTime(DateTime.Now.Date.AddDays(7)); 
                day = day.AddDays(1))
            {
                if (fullAppointment.Where(app => DateOnly.FromDateTime(app.TimeStart) == day).Count() < 2*12)
                {
                    dates.Add(day);
                }
                
            }
            return dates;
        }

        public async Task<bool> IsAppointmentExists(DateTime date, int? medicId)
        {
            if (medicId is null)
            {
                return _context.Appointments.Where(t => t.TimeStart == date).Any();
            }
            return _context.Appointments.Where(t => t.TimeStart == date && t.MedicId == medicId).Any();    
        }

        public async Task<bool> SetAppointment(DateTime date, int userId, int medicId)
        {
            var model = new AppointmentModel {
                TimeStart = date,
                TimeEnd = date.AddMinutes(30),
                UserId = userId,
                MedicId = medicId,
            };
            await _context.Appointments.AddAsync(model);
            return await _context.Appointments.ContainsAsync(model);
        }
    }
}
