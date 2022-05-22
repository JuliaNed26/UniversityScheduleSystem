
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UniversityScheduleSystem.Models;

namespace UniversityScheduleSystem.Models
{
    public class ScheduleSystemAPIContext:DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Teaching> Teachings { get; set; }
        public DbSet<TeacherUniversity> TeacherUniversities { get; set; }

        public ScheduleSystemAPIContext(DbContextOptions<ScheduleSystemAPIContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        private void CreateTeachingsTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teaching>()
                .HasOne(j => j.Teacher)
                .WithMany(t => t.Teachings)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Teaching>()
                .HasOne(j => j.Discipline)
                .WithMany(d => d.Teachings)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Teaching>()
                .HasOne(j => j.Faculty)
                .WithMany(f => f.Teachings)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void CreateLessonsTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Group)
                .WithMany(g => g.Lessons)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Lesson>()
                 .HasOne(l => l.Teaching)
                 .WithMany(ftd => ftd.Lessons)
                 .OnDelete(DeleteBehavior.Restrict);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateTeachingsTable(modelBuilder);
            CreateLessonsTable(modelBuilder);
        }

    }
}
