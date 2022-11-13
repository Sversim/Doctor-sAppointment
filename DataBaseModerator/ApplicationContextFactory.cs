using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataBaseModerator
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql(
                $"Host=localhost;Port=5432;Database=DoctorsBase;Username=postgres;Password=post");
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
