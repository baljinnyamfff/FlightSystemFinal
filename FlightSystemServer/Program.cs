using FlightSystemDatabase.Repository;
using Microsoft.EntityFrameworkCore;
using FlightSystemDatabase;
using FlightSystemDatabase.Model;
using FlightSystemService;
using FlightSystemService.Service;
using FlightSystemService.SignalRHub;
using FlightSystemServer;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddSignalR();

builder.Services.AddSignalR(options =>
{
    options.MaximumReceiveMessageSize = 102400; // 100 KB
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
builder.Services.AddScoped<ISeatRepository, SeatRepository>();
builder.Services.AddScoped<IBoardingPassRepository, BoardingPassRepository>();

builder.Services.AddScoped<ICheckInService, CheckInService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<IPassengerService, PassengerService>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddScoped<IBoardingPassService, BoardingPassService>();
builder.Services.AddScoped<INotificationService, NotificationService>();


//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
//    });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins("https://localhost:7211")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddSingleton<SocketWorker>();
builder.Services.AddSingleton<ISocketWorker>(provider => provider.GetRequiredService<SocketWorker>());
builder.Services.AddHostedService(provider => provider.GetRequiredService<SocketWorker>());

builder.Logging.SetMinimumLevel(LogLevel.Debug);


var app = builder.Build();


app.UseRouting();

app.UseCors("AllowAll");

app.MapHub<FlightHub>("/flightHub");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataBaseContext>();

    if (!db.Flights.Any())
    {
        var flight = new Flight
        {
            FlightNumber = "HK4701",
            Destination = "Hong-Kong",
            DepartureTime = DateTime.UtcNow.AddHours(2),
            Status = FlightStatus.CheckingIn,
            Seats = new List<Seat>
            {
                new Seat { SeatNumber = "A1", IsAssigned = false },
                new Seat { SeatNumber = "A2", IsAssigned = false }
            }
        };

        db.Flights.Add(flight);
        db.SaveChanges();

        var passenger = new Passenger
        {
            Name = "John Doe",
            PassportNumber = "P1234567",
            FlightId = flight.Id
        };

        db.Passengers.Add(passenger);
        db.SaveChanges();
    }
}