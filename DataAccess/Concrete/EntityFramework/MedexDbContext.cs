using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class MedexDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Medex;Trusted_Connection=true");
        }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
