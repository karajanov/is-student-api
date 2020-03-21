﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniversityApp.Models;

namespace UniversityApp.Migrations
{
    [DbContext(typeof(UniversityAppContext))]
    partial class UniversityAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UniversityApp.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400)
                        .IsUnicode(true);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400)
                        .IsUnicode(true);

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "London",
                            Country = "UK",
                            Street = "Frying Pan Road"
                        },
                        new
                        {
                            Id = 2,
                            City = "Cincinnati",
                            Country = "USA",
                            Street = "Error Place"
                        },
                        new
                        {
                            Id = 3,
                            City = "Rome",
                            Country = "Italy",
                            Street = "Bad Route Road"
                        },
                        new
                        {
                            Id = 4,
                            City = "Las Vegas",
                            Country = "USA",
                            Street = "Pillow Talk Court"
                        },
                        new
                        {
                            Id = 5,
                            City = "Berlin",
                            Country = "Germany",
                            Street = "This Street"
                        });
                });

            modelBuilder.Entity("UniversityApp.Models.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Credits")
                        .HasColumnType("decimal(4)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400)
                        .IsUnicode(true);

                    b.Property<string>("ProfessorName")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.ToTable("Exams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Credits = 6m,
                            Name = "Computer Programming",
                            ProfessorName = "Nicoline Abspoel"
                        },
                        new
                        {
                            Id = 2,
                            Credits = 5m,
                            Name = "Computer Architecture",
                            ProfessorName = "Ashlynn Van Hautum"
                        },
                        new
                        {
                            Id = 3,
                            Credits = 5.5m,
                            Name = "Databases",
                            ProfessorName = "Andrew Kennard"
                        },
                        new
                        {
                            Id = 4,
                            Credits = 5m,
                            Name = "Discrete Mathematics",
                            ProfessorName = "Algernon Aarse"
                        },
                        new
                        {
                            Id = 5,
                            Credits = 5m,
                            Name = "Data Structures and Algorithms",
                            ProfessorName = "Sampson Daelmans"
                        },
                        new
                        {
                            Id = 6,
                            Credits = 5.5m,
                            Name = "Operating Systems",
                            ProfessorName = "Ermintrude Royceston"
                        });
                });

            modelBuilder.Entity("UniversityApp.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnName("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DOB")
                        .HasColumnName("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnName("EnrollmentDate")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(true);

                    b.Property<decimal?>("GPA")
                        .HasColumnName("GPA")
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400)
                        .IsUnicode(true);

                    b.Property<string>("Mail")
                        .HasColumnName("Mail")
                        .HasColumnType("nvarchar(400)")
                        .HasMaxLength(400);

                    b.Property<string>("StudentIndex")
                        .IsRequired()
                        .HasColumnName("StudentIndex")
                        .HasColumnType("char(4)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 2,
                            EnrollmentDate = new DateTime(2017, 3, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            FirstName = "Kassidy",
                            LastName = "Trueman",
                            Mail = "Kassidy.Trueman@mail.com",
                            StudentIndex = "3516"
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 5,
                            EnrollmentDate = new DateTime(2016, 3, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            FirstName = "Christobel",
                            LastName = "Bezuidenhout",
                            Mail = "Christobel.Bezuidenhout@mail.com",
                            StudentIndex = "1241"
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 1,
                            EnrollmentDate = new DateTime(2018, 3, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            FirstName = "Kristel",
                            LastName = "Madison",
                            Mail = "Kristel.Madison@mail.com",
                            StudentIndex = "3121"
                        },
                        new
                        {
                            Id = 4,
                            AddressId = 3,
                            EnrollmentDate = new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            FirstName = "Lyndsey",
                            LastName = "Albers",
                            Mail = "Lyndsey.Albers@mail.com",
                            StudentIndex = "1415"
                        },
                        new
                        {
                            Id = 5,
                            AddressId = 4,
                            EnrollmentDate = new DateTime(2017, 3, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            FirstName = "Alishia",
                            LastName = "Gabriels",
                            Mail = "Alishia.Gabriels@mail.com",
                            StudentIndex = "3717"
                        });
                });

            modelBuilder.Entity("UniversityApp.Models.Transcript", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<decimal>("Points")
                        .HasColumnType("decimal(4)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("StudentId");

                    b.ToTable("Transcripts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExamId = 1,
                            Points = 90m,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 3,
                            ExamId = 5,
                            Points = 88m,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 2,
                            ExamId = 2,
                            Points = 65m,
                            StudentId = 3
                        },
                        new
                        {
                            Id = 4,
                            ExamId = 2,
                            Points = 75m,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 6,
                            ExamId = 1,
                            Points = 81m,
                            StudentId = 2
                        },
                        new
                        {
                            Id = 7,
                            ExamId = 3,
                            Points = 75.5m,
                            StudentId = 2
                        },
                        new
                        {
                            Id = 8,
                            ExamId = 6,
                            Points = 98m,
                            StudentId = 2
                        },
                        new
                        {
                            Id = 9,
                            ExamId = 5,
                            Points = 61m,
                            StudentId = 2
                        },
                        new
                        {
                            Id = 10,
                            ExamId = 2,
                            Points = 65m,
                            StudentId = 3
                        },
                        new
                        {
                            Id = 11,
                            ExamId = 1,
                            Points = 79m,
                            StudentId = 3
                        },
                        new
                        {
                            Id = 12,
                            ExamId = 6,
                            Points = 67m,
                            StudentId = 3
                        },
                        new
                        {
                            Id = 13,
                            ExamId = 1,
                            Points = 96m,
                            StudentId = 4
                        },
                        new
                        {
                            Id = 14,
                            ExamId = 2,
                            Points = 89m,
                            StudentId = 4
                        },
                        new
                        {
                            Id = 15,
                            ExamId = 3,
                            Points = 78m,
                            StudentId = 4
                        },
                        new
                        {
                            Id = 16,
                            ExamId = 4,
                            Points = 94m,
                            StudentId = 4
                        },
                        new
                        {
                            Id = 17,
                            ExamId = 5,
                            Points = 91m,
                            StudentId = 4
                        },
                        new
                        {
                            Id = 18,
                            ExamId = 6,
                            Points = 82m,
                            StudentId = 4
                        },
                        new
                        {
                            Id = 19,
                            ExamId = 3,
                            Points = 83m,
                            StudentId = 5
                        },
                        new
                        {
                            Id = 20,
                            ExamId = 6,
                            Points = 78m,
                            StudentId = 5
                        },
                        new
                        {
                            Id = 21,
                            ExamId = 5,
                            Points = 84m,
                            StudentId = 5
                        },
                        new
                        {
                            Id = 22,
                            ExamId = 2,
                            Points = 69m,
                            StudentId = 5
                        });
                });

            modelBuilder.Entity("UniversityApp.Models.Student", b =>
                {
                    b.HasOne("UniversityApp.Models.Address", "Address")
                        .WithMany("Students")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("UniversityApp.Models.Transcript", b =>
                {
                    b.HasOne("UniversityApp.Models.Exam", "Exam")
                        .WithMany("Students")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("UniversityApp.Models.Student", "Student")
                        .WithMany("Exams")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
