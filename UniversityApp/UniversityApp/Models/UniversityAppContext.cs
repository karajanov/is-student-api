using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace UniversityApp.Models
{
    public class UniversityAppContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public UniversityAppContext(DbContextOptions<UniversityAppContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Exam> Exams { get; set; }

        public virtual DbSet<Transcript> Transcripts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Id)
                .UseIdentityColumn(1, 1);

                entity.Property(a => a.Street)
                    .HasMaxLength(400)
                    .IsUnicode(true)
                    .IsRequired(false);

                entity.Property(a => a.City)
                    .HasMaxLength(400)
                    .IsUnicode(true)
                    .IsRequired(false);

                entity.Property(a => a.Country)
                    .HasMaxLength(400)
                    .IsUnicode(true)
                    .IsRequired(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Id)
                .UseIdentityColumn(1, 1);

                entity.Property(s => s.FirstName)
                    .HasMaxLength(200)
                    .IsUnicode(true)
                    .IsRequired(false);

                entity.Property(s => s.LastName)
                    .HasMaxLength(400)
                    .IsUnicode(true)
                    .IsRequired(false);

                entity.Property(s => s.DOB)
                    .HasColumnName("DateOfBirth")
                    .HasColumnType("datetime")
                    .IsRequired(false);

                entity.Property(s => s.EnrollmentDate)
                    .HasColumnName("EnrollmentDate")
                    .HasColumnType("datetime")
                    .IsRequired(true);

                entity.Property(s => s.Mail)
                    .HasColumnName("Mail")
                    .HasMaxLength(400)
                    .IsRequired(false);

                entity.Property(s => s.StudentIndex)
                    .HasColumnName("StudentIndex")
                    .HasColumnType("char(4)")
                    .IsRequired(true);

                entity.Property(s => s.GPA)
                    .HasColumnName("GPA")
                    .HasColumnType("decimal(3,2)")
                    .IsRequired(false);

                entity.Property(s => s.AddressId)
                    .HasColumnName("AddressId")
                    .HasColumnType("int")
                    .IsRequired(true);

                entity
                    .HasOne(s => s.Address)
                    .WithMany(a => a.Students)
                    .HasForeignKey(s => s.AddressId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity
                    .HasKey(e => e.Id);

                entity.Property(e => e.Id)
                .UseIdentityColumn(1, 1);

                entity.Property(a => a.Name)
                    .HasMaxLength(400)
                    .IsUnicode(true)
                    .IsRequired(false);

                entity.Property(a => a.ProfessorName)
                    .HasMaxLength(400)
                    .IsUnicode(true)
                    .IsRequired(false);

                entity.Property(a => a.Credits)
                    .HasColumnType("decimal(4)")
                    .IsRequired(true);
            });

            modelBuilder.Entity<Transcript>(entity =>
            {
                entity
                    .HasKey(t => t.Id);

                entity.Property(t => t.Id)
                .UseIdentityColumn(1, 1);

                entity.Property(a => a.StudentId)
                    .IsRequired(true);

                entity.Property(a => a.ExamId)
                    .IsRequired(true);

                entity.Property(a => a.Points)
                    .HasColumnType("decimal(4)")
                    .IsRequired(true);

                entity
                    .HasOne(t => t.Student)
                    .WithMany(s => s.Exams)
                    .HasForeignKey(t => t.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(t => t.Exam)
                    .WithMany(e => e.Students)
                    .HasForeignKey(t => t.ExamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Address>().HasData(
               new Address { Id = 1, City = "London", Street = "Frying Pan Road", Country = "UK" },
               new Address { Id = 2, City = "Cincinnati", Street = "Error Place", Country = "USA" },
               new Address { Id = 3, City = "Rome", Street = "Bad Route Road", Country = "Italy" },
               new Address { Id = 4, City = "Las Vegas", Street = "Pillow Talk Court", Country = "USA" },
               new Address { Id = 5, City = "Berlin", Street = "This Street", Country = "Germany" });

            modelBuilder.Entity<Exam>()
                .HasData(
                new Exam { Id = 1, Name = "Computer Programming", ProfessorName = "Nicoline Abspoel", Credits = 6 },
                new Exam { Id = 2, Name = "Computer Architecture", ProfessorName = "Ashlynn Van Hautum", Credits = 5 },
                new Exam { Id = 3, Name = "Databases", ProfessorName = "Andrew Kennard", Credits = (decimal)5.5 },
                new Exam { Id = 4, Name = "Discrete Mathematics", ProfessorName = "Algernon Aarse", Credits = 5 },
                new Exam
                {
                    Id = 5,
                    Name = "Data Structures and Algorithms",
                    ProfessorName = "Sampson Daelmans",
                    Credits = 5
                },
                new Exam
                {
                    Id = 6,
                    Name = "Operating Systems",
                    ProfessorName = "Ermintrude Royceston",
                    Credits = (decimal)5.5
                });

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Kassidy",
                    LastName = "Trueman",
                    StudentIndex = "3516",
                    AddressId = 2,
                    Mail = "Kassidy.Trueman@mail.com",
                    EnrollmentDate = DateTime.Today.AddYears(-3)
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Christobel",
                    LastName = "Bezuidenhout",
                    StudentIndex = "1241",
                    AddressId = 5,
                    Mail = "Christobel.Bezuidenhout@mail.com",
                    EnrollmentDate = DateTime.Today.AddYears(-4)
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Kristel",
                    LastName = "Madison",
                    StudentIndex = "3121",
                    AddressId = 1,
                    Mail = "Kristel.Madison@mail.com",
                    EnrollmentDate = DateTime.Today.AddYears(-2)
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Lyndsey",
                    LastName = "Albers",
                    StudentIndex = "1415",
                    AddressId = 3,
                    Mail = "Lyndsey.Albers@mail.com",
                    EnrollmentDate = DateTime.Today.AddYears(-1)
                },
                new Student
                {
                    Id = 5,
                    FirstName = "Alishia",
                    LastName = "Gabriels",
                    StudentIndex = "3717",
                    AddressId = 4,
                    Mail = "Alishia.Gabriels@mail.com",
                    EnrollmentDate = DateTime.Today.AddYears(-3)
                });

            modelBuilder.Entity<Transcript>().HasData(
                new Transcript
                {
                    Id = 1,
                    ExamId = 1,
                    StudentId = 1,
                    Points = 90
                },
                new Transcript
                {
                    Id = 3,
                    ExamId = 5,
                    StudentId = 1,
                    Points = 88
                },
                new Transcript
                {
                    Id = 2,
                    ExamId = 2,
                    StudentId = 3,
                    Points = 65
                },
                new Transcript
                {
                    Id = 4,
                    ExamId = 2,
                    StudentId = 1,
                    Points = 75
                },
                new Transcript
                {
                    Id = 6,
                    ExamId = 1,
                    StudentId = 2,
                    Points = 81
                },
                new Transcript
                {
                    Id = 7,
                    ExamId = 3,
                    StudentId = 2,
                    Points = (decimal)75.5
                },
                new Transcript
                {
                    Id = 8,
                    ExamId = 6,
                    StudentId = 2,
                    Points = 98
                },
                new Transcript
                {
                    Id = 9,
                    ExamId = 5,
                    StudentId = 2,
                    Points = 61
                },
                new Transcript
                {
                    Id = 10,
                    ExamId = 2,
                    StudentId = 3,
                    Points = 65
                },
                new Transcript
                {
                    Id = 11,
                    ExamId = 1,
                    StudentId = 3,
                    Points = 79
                },
                new Transcript
                {
                    Id = 12,
                    ExamId = 6,
                    StudentId = 3,
                    Points = 67
                },
                new Transcript
                {
                    Id = 13,
                    ExamId = 1,
                    StudentId = 4,
                    Points = 96
                },
                new Transcript
                {
                    Id = 14,
                    ExamId = 2,
                    StudentId = 4,
                    Points = 89
                },
                new Transcript
                {
                    Id = 15,
                    ExamId = 3,
                    StudentId = 4,
                    Points = 78
                },
                new Transcript
                {
                    Id = 16,
                    ExamId = 4,
                    StudentId = 4,
                    Points = 94
                },
                new Transcript
                {
                    Id = 17,
                    ExamId = 5,
                    StudentId = 4,
                    Points = 91
                },
                new Transcript
                {
                    Id = 18,
                    ExamId = 6,
                    StudentId = 4,
                    Points = 82
                },
                new Transcript
                {
                    Id = 19,
                    ExamId = 3,
                    StudentId = 5,
                    Points = 83
                },
                new Transcript
                {
                    Id = 20,
                    ExamId = 6,
                    StudentId = 5,
                    Points = 78
                },
                new Transcript
                {
                    Id = 21,
                    ExamId = 5,
                    StudentId = 5,
                    Points = 84
                },
                new Transcript
                {
                    Id = 22,
                    ExamId = 2,
                    StudentId = 5,
                    Points = 69
                });
        }

    }
}
