using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Entities
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
            //Database.EnsureCreated(); //Se não existir garante a sua criação
            //Database.Migrate(); //Executa as migrações
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        //Um outro modo de mudar a conexão de BD
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var cities = new List<City>()
            //{
            //    new City()
            //    {
            //         Name = "New York City",
            //         Description = "The one with that big park.",
            //         //PointsOfInterest = new List<PointOfInterest>()
            //         //{
            //         //    new PointOfInterest() {
            //         //        Name = "Central Park",
            //         //        Description = "The most visited urban park in the United States.",
            //         //        CityId = 1
            //         //    },
            //         //     new PointOfInterest() {
            //         //        Name = "Empire State Building",
            //         //        Description = "A 102-story skyscraper located in Midtown Manhattan.",
            //         //        CityId = 1
            //         //     },
            //         //}
            //    }//,
            //    //new City()
            //    //{
            //    //    Name = "Antwerp",
            //    //    Description = "The one with the cathedral that was never really finished.",
            //    //    PointsOfInterest = new List<PointOfInterest>()
            //    //     {
            //    //         new PointOfInterest() {
            //    //             Name = "Cathedral",
            //    //             Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
            //    //         },
            //    //          new PointOfInterest() {
            //    //             Name = "Antwerp Central Station",
            //    //             Description = "The the finest example of railway architecture in Belgium."
            //    //          },
            //    //     }
            //    //},
            //    //new City()
            //    //{
            //    //    Name = "Paris",
            //    //    Description = "The one with that big tower.",
            //    //    PointsOfInterest = new List<PointOfInterest>()
            //    //     {
            //    //         new PointOfInterest() {
            //    //             Name = "Eiffel Tower",
            //    //             Description =  "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
            //    //         },
            //    //          new PointOfInterest() {
            //    //             Name = "The Louvre",
            //    //             Description = "The world's largest museum."
            //    //          },
            //    //     }
            //    //}
            //};

            //Tentativa de seed
            //modelBuilder.Entity<City>().HasData(cities.ToArray());

            /* OBS
             * update-database ERROR Parameter count mismatch
             * Erro ocorre se no hasData não receber um ARRAY
             */


            base.OnModelCreating(modelBuilder);
        }
    }
}
