using Beam.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Data.Models
{
    public class BeamContext : DbContext
    {
        public BeamContext(DbContextOptions<BeamContext> options) : base(options)
        {
        }

        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<Ray> Rays { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Prism> Prisms { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Frequency>().ToTable("Frequency");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Ray>().ToTable("Ray");
            modelBuilder.Entity<Prism>().ToTable("Prism");
        }

        
    }

    public class Frequency
    {
        public int FrequencyId { get; set; }
        public string Name { get; set; }
        public List<Ray> Rays { get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public List<Ray> Rays { get; set; }
        public List<Prism> Prisms { get; set; }
    }

    public class Ray
    {
        public int RayId { get; set; }
        public string Text { get; set; }
        public int FrequencyId { get; set; }
        public Frequency Frequency { get; set; }
        public List<Prism> Prisms { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }

    public class Prism
    {
        public int PrismId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RayId { get; set; }
        public Ray Ray { get; set; }
    }
}
