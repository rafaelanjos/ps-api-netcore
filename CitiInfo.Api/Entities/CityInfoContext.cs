using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Entities
{
    public class CityInfoContext: DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options) : base(options)
        {
            //Database.EnsureCreated(); //Se não existir garante a sua criação
            Database.Migrate(); //Executa as migrações
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        //Um outro modo de mudar a conexão de BD
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
