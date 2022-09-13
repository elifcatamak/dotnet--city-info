using CityInfo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Api.DbContexts;

public class CityInfoContext : DbContext
{
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<PointOfInterest> PointsOfInterest { get; set; } = null!;

    public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>().HasData(
            new City("New York City")
            {
                Id = 1,
                Description = "The one with that big park"
            },
            new City("Antwerp")
            {
                Id = 2,
                Description = "The one with that cathedral that was never really finished."
            },
            new City("Paris")
            {
                Id = 3,
                Description = "The one with that big tower"
            }
        );

        modelBuilder.Entity<PointOfInterest>().HasData(
            new PointOfInterest("Central Park")
            {
                Id = 1,
                Description = "The most visited urban park in the United States.",
                CityId = 1
            },
            new PointOfInterest("Empire State Building")
            {
                Id = 2,
                Description = "A 102-story skyscraper located in Midtown Manhattan.",
                CityId = 1
            },
            new PointOfInterest("Cathedral")
            {
                Id = 3,
                Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans.",
                CityId = 2
            },
            new PointOfInterest("Antwerp Central Station")
            {
                Id = 4,
                Description = "The the finest example of railway architecture in Belgium.",
                CityId = 2
            },
            new PointOfInterest("Eiffel Tower")
            {
                Id = 5,
                Description = "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel.",
                CityId = 3
            },
            new PointOfInterest("The Louvre")
            {
                Id = 6,
                Description = "The world's largest museum.",
                CityId = 3
            }
        );

        base.OnModelCreating(modelBuilder);
    }
}