using BaseApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Entity
{
    public class OlympicDB : DbContext
    {
        public OlympicDB() : base("OlimpicDb")  {     }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<WeightLimite> WeightLimites { get; set; }
        public DbSet<LengthLimite> LengthLimites { get; set; }
        public DbSet<SportType> SportTypes { get; set; }
        public DbSet<SubSportType> SubSportTypes { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Medal> Medals { get; set; }
        public DbSet<Athlet> Athlets { get; set; }
    }

    //public class DbInit : CreateDatabaseIfNotExists<OlimpicDBContext>
    //{
    //    //data seeding
    //    protected override void Seed(OlimpicDBContext context)
    //    {
    //        base.Seed(context);
    //    }
    //}
}
