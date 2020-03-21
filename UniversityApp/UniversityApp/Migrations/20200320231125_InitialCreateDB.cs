using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityApp.Migrations
{
    public partial class InitialCreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(maxLength: 400, nullable: true),
                    City = table.Column<string>(maxLength: 400, nullable: true),
                    Country = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 400, nullable: true),
                    ProfessorName = table.Column<string>(maxLength: 400, nullable: true),
                    Credits = table.Column<decimal>(type: "decimal(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 200, nullable: true),
                    LastName = table.Column<string>(maxLength: 400, nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    Mail = table.Column<string>(maxLength: 400, nullable: true),
                    StudentIndex = table.Column<string>(type: "char(4)", nullable: false),
                    GPA = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transcripts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    Points = table.Column<decimal>(type: "decimal(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transcripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transcripts_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transcripts_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "Street" },
                values: new object[,]
                {
                    { 1, "London", "UK", "Frying Pan Road" },
                    { 2, "Cincinnati", "USA", "Error Place" },
                    { 3, "Rome", "Italy", "Bad Route Road" },
                    { 4, "Las Vegas", "USA", "Pillow Talk Court" },
                    { 5, "Berlin", "Germany", "This Street" }
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "Credits", "Name", "ProfessorName" },
                values: new object[,]
                {
                    { 1, 6m, "Computer Programming", "Nicoline Abspoel" },
                    { 2, 5m, "Computer Architecture", "Ashlynn Van Hautum" },
                    { 3, 5.5m, "Databases", "Andrew Kennard" },
                    { 4, 5m, "Discrete Mathematics", "Algernon Aarse" },
                    { 5, 5m, "Data Structures and Algorithms", "Sampson Daelmans" },
                    { 6, 5.5m, "Operating Systems", "Ermintrude Royceston" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AddressId", "DateOfBirth", "EnrollmentDate", "FirstName", "GPA", "LastName", "Mail", "StudentIndex" },
                values: new object[,]
                {
                    { 3, 1, null, new DateTime(2018, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), "Kristel", null, "Madison", "Kristel.Madison@mail.com", "3121" },
                    { 1, 2, null, new DateTime(2017, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), "Kassidy", null, "Trueman", "Kassidy.Trueman@mail.com", "3516" },
                    { 4, 3, null, new DateTime(2019, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), "Lyndsey", null, "Albers", "Lyndsey.Albers@mail.com", "1415" },
                    { 5, 4, null, new DateTime(2017, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), "Alishia", null, "Gabriels", "Alishia.Gabriels@mail.com", "3717" },
                    { 2, 5, null, new DateTime(2016, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), "Christobel", null, "Bezuidenhout", "Christobel.Bezuidenhout@mail.com", "1241" }
                });

            migrationBuilder.InsertData(
                table: "Transcripts",
                columns: new[] { "Id", "ExamId", "Points", "StudentId" },
                values: new object[,]
                {
                    { 2, 2, 65m, 3 },
                    { 7, 3, 75.5m, 2 },
                    { 6, 1, 81m, 2 },
                    { 22, 2, 69m, 5 },
                    { 21, 5, 84m, 5 },
                    { 20, 6, 78m, 5 },
                    { 19, 3, 83m, 5 },
                    { 18, 6, 82m, 4 },
                    { 17, 5, 91m, 4 },
                    { 8, 6, 98m, 2 },
                    { 16, 4, 94m, 4 },
                    { 14, 2, 89m, 4 },
                    { 13, 1, 96m, 4 },
                    { 4, 2, 75m, 1 },
                    { 3, 5, 88m, 1 },
                    { 1, 1, 90m, 1 },
                    { 12, 6, 67m, 3 },
                    { 11, 1, 79m, 3 },
                    { 10, 2, 65m, 3 },
                    { 15, 3, 78m, 4 },
                    { 9, 5, 61m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                table: "Students",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_ExamId",
                table: "Transcripts",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Transcripts_StudentId",
                table: "Transcripts",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transcripts");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
