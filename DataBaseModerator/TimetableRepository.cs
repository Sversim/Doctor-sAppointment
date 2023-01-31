using Domain;
using Microsoft.EntityFrameworkCore;
using MyFirstClassLibrary;

namespace DataBaseModerator
{
    public class TimetableRepository : ITimetableRepository
    {
        private ApplicationContext _context;
        public TimetableRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Timetable?> GetMedicsTimetable(int medicId, DateTime date)
        {
            var timetable = await _context.Timetables.FirstAsync(m => m.MedicId == medicId 
                && DateOnly.FromDateTime(date) == DateOnly.FromDateTime(m.TimeStart));
            return timetable.ToDomain();
        }

        public async Task<bool> SetMedicsTimetable(Timetable timetable)
        {
            var ttToInsert = new TimetableModel(timetable.MedicId, timetable.TimeStart, timetable.TimeEnd);
            await _context.Timetables.AddAsync(ttToInsert);
            return await _context.Timetables.ContainsAsync(ttToInsert);
        }
    }
}
