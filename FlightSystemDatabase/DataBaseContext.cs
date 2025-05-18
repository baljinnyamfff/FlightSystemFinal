using Microsoft.EntityFrameworkCore;
using FlightSystemDatabase.Model;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FlightSystemDatabase;

public class DataBaseContext : DbContext
{
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<BoardingPass> BoardingPasses { get; set; }

    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>()
            .HasMany(f => f.Seats)
            .WithOne(s => s.Flight)
            .HasForeignKey(s => s.FlightId);

        modelBuilder.Entity<Passenger>()
            .HasOne(p => p.Flight)
            .WithMany()
            .HasForeignKey(p => p.FlightId);

        modelBuilder.Entity<Passenger>()
            .HasOne(p => p.Seat)
            .WithOne(s => s.Passenger)
            .HasForeignKey<Seat>(s => s.PassengerId);

        modelBuilder.Entity<BoardingPass>()
            .HasOne(bp => bp.Passenger)
            .WithMany(p => p.BoardingPasses)
            .HasForeignKey(bp => bp.PassengerId);

        modelBuilder.Entity<BoardingPass>()
            .HasOne(bp => bp.Seat)
            .WithMany()
            .HasForeignKey(bp => bp.SeatId);

        modelBuilder.Entity<BoardingPass>()
            .HasOne(bp => bp.Flight)
            .WithMany()
            .HasForeignKey(bp => bp.FlightId);

        modelBuilder.Entity<Passenger>()
            .HasIndex(p => p.PassportNumber)
            .IsUnique();
    }
}