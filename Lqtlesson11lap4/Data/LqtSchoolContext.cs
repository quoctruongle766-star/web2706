using Microsoft.EntityFrameworkCore;
using Lqtlesson11lap4.Models;

namespace Lqtlesson11lap4.Data
{
    public class LqtSchoolContext : DbContext
    {
        public LqtSchoolContext(DbContextOptions<LqtSchoolContext> options) : base(options) { }

        public virtual DbSet<LqtCourse> Courses { get; set; }
        public virtual DbSet<LqtLearner> Learners { get; set; }
        public virtual DbSet<LqtEnrollment> Enrollments { get; set; }
        public virtual DbSet<LqtMajor> Majors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LqtMajor>().ToTable(nameof(Major)).HasKey(m => m.MajorID);
            modelBuilder.Entity<LqtCourse>().ToTable(nameof(Course)).HasKey(c => c.CourseID);
            modelBuilder.Entity<LqtLearner>().ToTable(nameof(Learner)).HasKey(l => l.LearnerID);
            modelBuilder.Entity<LqtEnrollment>().ToTable(nameof(Enrollment)).HasKey(e => e.EnrollmentID);
        }
    }
}
