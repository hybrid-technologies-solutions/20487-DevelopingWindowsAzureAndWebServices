﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlueYonder.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BlueYonderEntities : DbContext
    {
        public BlueYonderEntities()
            : base("name=BlueYonderEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<FlightSchedule> FlightSchedules { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Traveler> Travelers { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
    }
}
