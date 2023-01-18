using MyFirstClassLibrary;
using DataBaseModerator;
using Microsoft.EntityFrameworkCore;
using Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql($"Host=localhost;Port=5432;Database=DoctorsBase;Username=postgres;Password=post"));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<UserInteractor>();

builder.Services.AddTransient<IMedicRepository, MedicRepository>();
builder.Services.AddTransient<MedicInteractor>();

builder.Services.AddTransient<ITimetableRepository, TimetableRepository>();
builder.Services.AddTransient<TimetableInteractor>();

builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddTransient<AppointmentInteractor>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();