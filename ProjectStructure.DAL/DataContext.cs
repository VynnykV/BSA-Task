using Microsoft.EntityFrameworkCore;
using ProjectStructure.DAL.Entities;

namespace ProjectStructure.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne(t => t.Performer)
                .WithMany(u=>u.Tasks)
                .HasForeignKey(t=>t.PerformerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Task>()
                .HasOne(t => t.Project)
                .WithMany(p=>p.Tasks)
                .HasForeignKey(t=>t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Projects)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}