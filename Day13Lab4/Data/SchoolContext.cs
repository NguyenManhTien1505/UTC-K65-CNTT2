using Microsoft.EntityFrameworkCore;
using Day13Lab4.Models;

namespace Day13Lab4.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Learner> Learners { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Major>().ToTable("Major");
            modelBuilder.Entity<Learner>().ToTable("Learner");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        }
    }
}
