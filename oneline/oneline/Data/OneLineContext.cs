using Microsoft.EntityFrameworkCore;
using oneline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oneline.Data
{
    public class OneLineContext : DbContext
    {
        public OneLineContext(DbContextOptions<OneLineContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Score>()
                .HasOne<User>(s => s.User)
                .WithMany(g => g.Scores)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Score>()
                .HasOne<World>(s => s.World)
                .WithMany(g => g.Scores)
                .HasForeignKey(s => s.WorldIdx);

            modelBuilder.Entity<Achievement>()
                .HasOne<User>(s => s.User)
                .WithMany(g => g.Achievements)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Achievement>()
                .HasOne<World>(s => s.World)
                .WithMany(g => g.Achievements)
                .HasForeignKey(s => s.WorldIdx);

            modelBuilder.Entity<Achievement>()
                .HasOne<Quest>(s => s.Quest)
                .WithMany(g => g.Achievements)
                .HasForeignKey(s => s.QuestIdx);

            modelBuilder.Entity<Quest>()
                .HasOne<World>(s => s.World)
                .WithMany(g => g.Quests)
                .HasForeignKey(s => s.WorldIdx);
        }

        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<World> Worlds { get; set; }
    }
}
