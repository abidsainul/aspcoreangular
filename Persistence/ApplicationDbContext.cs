using System.Collections.Generic;
using aspnetcore_spa.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_spa.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Make> Makes { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // many-to-many vehicle - feature
            modelBuilder
                .Entity<Vehicle>()
                .HasMany(p => p.Features)
                .WithMany(p => p.Vehicles)
                .UsingEntity(j => j.ToTable("VehicleFeatures"));


            var make1 = new Make(){ Id=1, Name = "Make-1" };
            // make1.Models = new List<Model>();
            // make1.Models.Add(new Model(){ MakeId=1, Name = "Make1-ModelA"});
            // make1.Models.Add(new Model(){ MakeId=1, Name = "Make1-ModelB"});

            var make2 = new Make(){ Id=2,  Name = "Make-2" };
            // make2.Models = new List<Model>();
            // make2.Models.Add(new Model(){ MakeId=2, Name = "Make2-ModelA"});
            // make2.Models.Add(new Model(){ MakeId=2 ,Name = "Make2-ModelB"});

            modelBuilder.Entity<Make>().HasData(make1);
            modelBuilder.Entity<Make>().HasData(make2);

            modelBuilder.Entity<Model>().HasData(new Model(){ Id=1, MakeId=1, Name = "Make1-ModelA"} );
            modelBuilder.Entity<Model>().HasData(new Model(){ Id=2, MakeId=1, Name = "Make1-ModelB"} );

            modelBuilder.Entity<Model>().HasData(new Model(){ Id=3, MakeId=2, Name = "Make2-ModelA"} );
            modelBuilder.Entity<Model>().HasData(new Model(){ Id=4, MakeId=2, Name = "Make2-ModelB"} );
           
            modelBuilder.Entity<Feature>().HasData(new Feature(){ Id=1, Name = "Feature1"} );
            modelBuilder.Entity<Feature>().HasData(new Feature(){ Id=2, Name = "Feature2"} );
            modelBuilder.Entity<Feature>().HasData(new Feature(){ Id=3, Name = "Feature3"} );


        }
    }
}