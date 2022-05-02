
using Microsoft.EntityFrameworkCore;
using UniversityScheduleSystem.Models;

namespace UniversityScheduleSystem.Models
{
    public class ScheduleSystemAPIContext:DbContext
    {
        public DbSet<Region> Region { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Discipline> Discipline { get; set; }
        public DbSet<Teaching> Teaching { get; set; }


        public ScheduleSystemAPIContext(DbContextOptions<ScheduleSystemAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        private void CreateTeachingsTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teaching>()
                .HasOne(j => j.Teacher)
                .WithMany(t => t.Teachings)
                .HasForeignKey(j => j.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Teaching>()
                .HasOne(j => j.Discipline)
                .WithMany(d => d.Teachings)
                .HasForeignKey(j => j.DisciplineId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Teaching>()
                .HasOne(j => j.Faculty)
                .WithMany(f => f.Teachings)
                .HasForeignKey(j => j.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void CreateLessonsTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Group)
                .WithMany(g => g.Lessons)
                .HasForeignKey(l => l.GroupId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Lesson>()
                 .HasOne(l => l.Teaching)
                 .WithMany(ftd => ftd.Lessons)
                 .HasForeignKey(l => l.TeachingId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateTeachingsTable(modelBuilder);
            CreateLessonsTable(modelBuilder);
        }

    }
}
