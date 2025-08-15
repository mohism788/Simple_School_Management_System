using Microsoft.EntityFrameworkCore;
using School_Management_System.Models;

namespace School_Management_System.DataAccess
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentCourse",  // Join table name
                    j => j.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    j => j.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
                    j => j.ToTable("StudentCourses")  // Optional: custom table name
                );


            modelBuilder.Entity<Supply>()
               .HasOne(s => s.Student)          // A supply belongs to one student
               .WithMany(s => s.Supplies)       // A student has many supplies
               .HasForeignKey(s => s.StudentId) // Explicit foreign key
               .OnDelete(DeleteBehavior.Cascade); // Optional: Delete supplies if student is deleted
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Supply> Supplies { get; set; }
    }


    
    
}
