using Microsoft.EntityFrameworkCore;

namespace DataBaseModerator
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<MedicModel> Medics { get; set; }
        public DbSet<TimetableModel> Timetables { get; set; }
        public DbSet<AppointmentModel> Appointments { get; set; }

        public ApplicationContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DoctorsBase;Username=postgres;Password=post");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserModel>().HasIndex(model => model.Login);
        }
    }
}