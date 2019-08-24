using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlueYonder.Core.Model
{
    public partial class BlueYonderContext : DbContext
    {
        public BlueYonderContext()
        {
        }

        public BlueYonderContext(DbContextOptions<BlueYonderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FlightSchedules> FlightSchedules { get; set; }
        public virtual DbSet<Flights> Flights { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<Travelers> Travelers { get; set; }
        public virtual DbSet<Trips> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=blueyonder-cmo.database.windows.net;initial catalog=BlueYonder;user id=SQLAdmin;password=Pa$$word");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<FlightSchedules>(entity =>
            {
                entity.HasKey(e => e.FlightScheduleId)
                    .HasName("PK_dbo.FlightSchedules");

                entity.HasIndex(e => e.FlightId)
                    .HasName("IX_FlightId");

                entity.Property(e => e.ActualDeparture).HasColumnType("datetime");

                entity.Property(e => e.Departure).HasColumnType("datetime");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.FlightSchedules)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK_dbo.FlightSchedules_dbo.Flights_FlightId");
            });

            modelBuilder.Entity<Flights>(entity =>
            {
                entity.HasKey(e => e.FlightId)
                    .HasName("PK_dbo.Flights");

                entity.HasIndex(e => e.DestinationLocationId)
                    .HasName("IX_Destination_LocationId");

                entity.HasIndex(e => e.SourceLocationId)
                    .HasName("IX_Source_LocationId");

                entity.Property(e => e.DestinationLocationId).HasColumnName("Destination_LocationId");

                entity.Property(e => e.SourceLocationId).HasColumnName("Source_LocationId");

                entity.HasOne(d => d.DestinationLocation)
                    .WithMany(p => p.FlightsDestinationLocation)
                    .HasForeignKey(d => d.DestinationLocationId)
                    .HasConstraintName("FK_dbo.Flights_dbo.Locations_Destination_LocationId");

                entity.HasOne(d => d.SourceLocation)
                    .WithMany(p => p.FlightsSourceLocation)
                    .HasForeignKey(d => d.SourceLocationId)
                    .HasConstraintName("FK_dbo.Flights_dbo.Locations_Source_LocationId");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK_dbo.Locations");
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.HasKey(e => e.ReservationId)
                    .HasName("PK_dbo.Reservations");

                entity.HasIndex(e => e.DepartFlightScheduleId)
                    .HasName("IX_DepartFlightScheduleID");

                entity.HasIndex(e => e.ReturnFlightScheduleId)
                    .HasName("IX_ReturnFlightScheduleID");

                entity.Property(e => e.DepartFlightScheduleId).HasColumnName("DepartFlightScheduleID");

                entity.Property(e => e.ReservationDate).HasColumnType("datetime");

                entity.Property(e => e.ReturnFlightScheduleId).HasColumnName("ReturnFlightScheduleID");

                entity.HasOne(d => d.DepartFlightSchedule)
                    .WithMany(p => p.ReservationsDepartFlightSchedule)
                    .HasForeignKey(d => d.DepartFlightScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.Reservations_dbo.Trips_DepartFlightScheduleID");

                entity.HasOne(d => d.ReturnFlightSchedule)
                    .WithMany(p => p.ReservationsReturnFlightSchedule)
                    .HasForeignKey(d => d.ReturnFlightScheduleId)
                    .HasConstraintName("FK_dbo.Reservations_dbo.Trips_ReturnFlightScheduleID");
            });

            modelBuilder.Entity<Travelers>(entity =>
            {
                entity.HasKey(e => e.TravelerId)
                    .HasName("PK_dbo.Travelers");
            });

            modelBuilder.Entity<Trips>(entity =>
            {
                entity.HasKey(e => e.TripId)
                    .HasName("PK_dbo.Trips");

                entity.HasIndex(e => e.FlightScheduleId)
                    .HasName("IX_FlightScheduleID");

                entity.Property(e => e.FlightScheduleId).HasColumnName("FlightScheduleID");

                entity.HasOne(d => d.FlightSchedule)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.FlightScheduleId)
                    .HasConstraintName("FK_dbo.Trips_dbo.FlightSchedules_FlightScheduleID");
            });
        }
    }
}
