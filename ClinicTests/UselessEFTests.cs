using DataBaseModerator;
using Microsoft.EntityFrameworkCore;
using MyFirstClassLibrary;

namespace ClinicTests;

public class UselessEFTests
{
    private readonly DbContextOptionsBuilder<ApplicationContext> _optionsBuilder;

    public UselessEFTests()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
        optionsBuilder.UseNpgsql(
            $"Host=localhost;Port=5432;Database=DoctorsBase;Username=postgres;Password=post");
        _optionsBuilder = optionsBuilder;
    }

    [Fact]
    public void SearchByLoginn_OK()
    {
        using var context = new ApplicationContext(_optionsBuilder.Options);
        context.Users.Add(new UserModel
            (1, "+77777777", "Lorem", "Lorem", "Lorem?", Role.User));

        context.SaveChanges();
        Assert.True(context.Users.Any(u => u.Login == "Lorem"));
    }


    [Fact]
    public void SearchByLoginn_FAIL()
    {
        using var context = new ApplicationContext(_optionsBuilder.Options);
        var u = context.Users.FirstOrDefault(u => u.Login == "Lorem");
        context.Users.Remove(u);
        context.SaveChanges();

        Assert.True(!context.Users.Any(u => u.Login == "Lorem"));
    }


    [Fact]
    public void NotNullUserReturns()
    {
        using var context = new ApplicationContext(_optionsBuilder.Options);
        var userRepository = new UserRepository(context);
        var userService = new UserInteractor(userRepository);

        var res = userService.SearchUserWithLogin("Lorem");

        Assert.NotNull(res.Value);
    }
}