using EFCore_TEST.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_TEST.Data
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {

        }
        /*
        private const string connectionString = "server=localhost;port=3306;database=EFCoreMySQL;user=root;password=Tkdwo1229!mrp";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString);
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne<Grade>(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.CurrentGradeId);
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }

    }

}
