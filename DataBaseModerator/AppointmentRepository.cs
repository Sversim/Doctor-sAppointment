﻿using Domain;
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
        public List<DateOnly> GetTimeBySpec(Specialization specialization)
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
                // Здесь может потребоваться более продуманная логика
                // с предварительным выбором расписания врачей по специализациям,
                // но пока не вполне понятно, что именно требуется
                if (fullAppointment.Where(app => DateOnly.FromDateTime(app.TimeStart) == day).Count() < 2*12)
                {
                    // Магические числа:
                    // 2 - приёма в час
                    // 12 - часов в рабочем дне
                    dates.Add(day);
                }
                
            }
            return dates;
        }

        public bool IsAppointmentExists(DateTime date, int? medicId)
        {
            if (medicId is null)
            {
                return _context.Appointments.Where(t => t.TimeStart == date).Any();
            }
            return _context.Appointments.Where(t => t.TimeStart == date && t.MedicId == medicId).Any();    
        }

        public bool SetAppointment(DateTime date, int userId, int medicId)
        {
            //...date.AddMinutes(30)... - длина приёма
            //var id = _context.Appointments.Max(m => m.AppointmentId);
            var model = new AppointmentModel(date, date.AddMinutes(30), userId, medicId);
            _context.Appointments.Add(model);
            return _context.Appointments.Contains(model);
        }
    }
}
