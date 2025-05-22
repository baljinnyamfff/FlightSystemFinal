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
    options.MaximumReceiveMessageSize = 102400;
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
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();

    });
});

builder.Services.AddSingleton<SocketWorker>();
builder.Services.AddSingleton<ISocketWorker>(provider => provider.GetRequiredService<SocketWorker>());
builder.Services.AddHostedService(provider => provider.GetRequiredService<SocketWorker>());

builder.Logging.SetMinimumLevel(LogLevel.Debug);


var app = builder.Build();


app.UseRouting();

app.UseCors("CorsPolicy");

app.MapHub<FlightHub>("/flightHub");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataBaseContext>();

    if (!db.Flights.Any())
    {
        var flightList = new List<Flight>();
        var random = new Random();

        for (int i = 1; i <= 3; i++)
        {
            var flight = new Flight
            {
                FlightNumber = $"HK470{i}",
                Destination = $"City{i}",
                DepartureTime = DateTime.UtcNow.AddHours(i * 2),
                Status = FlightStatus.CheckingIn,
                Seats = new List<Seat>()
            };

            // Add 20 seats per flight
            for (int j = 1; j <= 20; j++)
            {
                flight.Seats.Add(new Seat
                {
                    SeatNumber = $"A{j}",
                    IsAssigned = false
                });
            }

            flightList.Add(flight);
        }

        db.Flights.AddRange(flightList);
        db.SaveChanges();

        // Add at least 10 passengers randomly distributed across flights
        var passengerNames = new[]
        {
        "John Doe", "Jane Smith", "Alice Brown", "Bob White", "Charlie Black",
        "Eva Green", "Frank Blue", "Grace Gray", "Henry Yellow", "Isla Red"
    };

        var passengers = new List<Passenger>();

        foreach (var name in passengerNames)
        {
            var flight = flightList[random.Next(flightList.Count)];

            passengers.Add(new Passenger
            {
                Name = name,
                PassportNumber = $"P{random.Next(1000000, 9999999)}",
                FlightId = flight.Id
            });
        }

        db.Passengers.AddRange(passengers);
        db.SaveChanges();
        Console.WriteLine("data initialized");
    }
    else
    {
        Console.WriteLine("Failed");
    }

    app.Run();
}