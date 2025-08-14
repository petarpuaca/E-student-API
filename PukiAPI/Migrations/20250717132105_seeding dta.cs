using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PukiAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedingdta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Profesori",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Predmeti",
                columns: new[] { "Id", "ESPB", "Naziv" },
                values: new object[,]
                {
                    { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), 0, "Matematika 1" },
                    { new Guid("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"), 0, "Matematika 2" },
                    { new Guid("a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3"), 0, "Programiranje" },
                    { new Guid("a4a4a4a4-a4a4-a4a4-a4a4-a4a4a4a4a4a4"), 0, "Baze Podataka" },
                    { new Guid("a5a5a5a5-a5a5-a5a5-a5a5-a5a5a5a5a5a5"), 0, "Web Programiranje" },
                    { new Guid("a6a6a6a6-a6a6-a6a6-a6a6-a6a6a6a6a6a6"), 0, "Računarske mreže" },
                    { new Guid("a7a7a7a7-a7a7-a7a7-a7a7-a7a7a7a7a7a7"), 0, "Operativni sistemi" },
                    { new Guid("a8a8a8a8-a8a8-a8a8-a8a8-a8a8a8a8a8a8"), 0, "Softversko inženjerstvo" },
                    { new Guid("a9a9a9a9-a9a9-a9a9-a9a9-a9a9a9a9a9a9"), 0, "Veštačka inteligencija" },
                    { new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"), 0, "Mašinsko učenje" },
                    { new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"), 0, "Algoritmi i strukture podataka" },
                    { new Guid("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"), 0, "Matematička logika" }
                });

            migrationBuilder.InsertData(
                table: "Profesori",
                columns: new[] { "Id", "Email", "Ime", "Prezime" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "marko.markovic@gmail.com", "Marko", "Marković" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "marko.markovic@gmail.com", "Ana", "Anić" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "ana.anic@gmail.com", "Ivan", "Ivanović" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "jelena.jelic@gmail.com", "Jelena", "Jelić" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "petar.petrovic@gmail.com", "Petar", "Petrović" }
                });

            migrationBuilder.InsertData(
                table: "Studenti",
                columns: new[] { "Id", "Ime", "Index", "Prezime", "Smer" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Luka", "2021/0001", "Jovanović", "IT" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Milica", "2021/0002", "Petrović", "Menadžment" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Nikola", "2021/0003", "Nikolić", "IT" },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Jovana", "2021/0004", "Stojanović", "Menadžment" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Stefan", "2021/0005", "Lazić", "IT" },
                    { new Guid("00000000-0000-0000-0000-000000000006"), "Ana", "2021/0006", "Đorđević", "IT" },
                    { new Guid("00000000-0000-0000-0000-000000000007"), "Filip", "2021/0007", "Ilić", "Menadžment" },
                    { new Guid("00000000-0000-0000-0000-000000000008"), "Tamara", "2021/0008", "Kovačević", "IT" },
                    { new Guid("00000000-0000-0000-0000-000000000009"), "Marko", "2021/0009", "Simić", "Menadžment" },
                    { new Guid("00000000-0000-0000-0000-000000000010"), "Sara", "2021/0010", "Mitrović", "IT" }
                });

            migrationBuilder.InsertData(
                table: "ProfesorPredmeti",
                columns: new[] { "PredmetId", "ProfesorId" },
                values: new object[,]
                {
                    { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("a6a6a6a6-a6a6-a6a6-a6a6-a6a6a6a6a6a6"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("a7a7a7a7-a7a7-a7a7-a7a7-a7a7a7a7a7a7"), new Guid("22222222-2222-2222-2222-222222222222") },
                    { new Guid("a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("a8a8a8a8-a8a8-a8a8-a8a8-a8a8a8a8a8a8"), new Guid("33333333-3333-3333-3333-333333333333") },
                    { new Guid("a4a4a4a4-a4a4-a4a4-a4a4-a4a4a4a4a4a4"), new Guid("44444444-4444-4444-4444-444444444444") },
                    { new Guid("a5a5a5a5-a5a5-a5a5-a5a5-a5a5a5a5a5a5"), new Guid("55555555-5555-5555-5555-555555555555") }
                });

            migrationBuilder.InsertData(
                table: "StudentPredmeti",
                columns: new[] { "PredmetId", "StudentId", "Ocena" },
                values: new object[,]
                {
                    { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("00000000-0000-0000-0000-000000000001"), 6 },
                    { new Guid("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"), new Guid("00000000-0000-0000-0000-000000000001"), 7 },
                    { new Guid("a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3"), new Guid("00000000-0000-0000-0000-000000000001"), 8 },
                    { new Guid("a4a4a4a4-a4a4-a4a4-a4a4-a4a4a4a4a4a4"), new Guid("00000000-0000-0000-0000-000000000001"), 9 },
                    { new Guid("a5a5a5a5-a5a5-a5a5-a5a5-a5a5a5a5a5a5"), new Guid("00000000-0000-0000-0000-000000000002"), 6 },
                    { new Guid("a6a6a6a6-a6a6-a6a6-a6a6-a6a6a6a6a6a6"), new Guid("00000000-0000-0000-0000-000000000002"), 7 },
                    { new Guid("a7a7a7a7-a7a7-a7a7-a7a7-a7a7a7a7a7a7"), new Guid("00000000-0000-0000-0000-000000000002"), 8 },
                    { new Guid("a8a8a8a8-a8a8-a8a8-a8a8-a8a8a8a8a8a8"), new Guid("00000000-0000-0000-0000-000000000002"), 9 },
                    { new Guid("a9a9a9a9-a9a9-a9a9-a9a9-a9a9a9a9a9a9"), new Guid("00000000-0000-0000-0000-000000000003"), 6 },
                    { new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"), new Guid("00000000-0000-0000-0000-000000000003"), 7 },
                    { new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"), new Guid("00000000-0000-0000-0000-000000000003"), 8 },
                    { new Guid("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"), new Guid("00000000-0000-0000-0000-000000000003"), 9 },
                    { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("00000000-0000-0000-0000-000000000004"), 6 },
                    { new Guid("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"), new Guid("00000000-0000-0000-0000-000000000004"), 7 },
                    { new Guid("a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3"), new Guid("00000000-0000-0000-0000-000000000004"), 8 },
                    { new Guid("a4a4a4a4-a4a4-a4a4-a4a4-a4a4a4a4a4a4"), new Guid("00000000-0000-0000-0000-000000000004"), 9 },
                    { new Guid("a5a5a5a5-a5a5-a5a5-a5a5-a5a5a5a5a5a5"), new Guid("00000000-0000-0000-0000-000000000005"), 6 },
                    { new Guid("a6a6a6a6-a6a6-a6a6-a6a6-a6a6a6a6a6a6"), new Guid("00000000-0000-0000-0000-000000000005"), 7 },
                    { new Guid("a7a7a7a7-a7a7-a7a7-a7a7-a7a7a7a7a7a7"), new Guid("00000000-0000-0000-0000-000000000005"), 8 },
                    { new Guid("a8a8a8a8-a8a8-a8a8-a8a8-a8a8a8a8a8a8"), new Guid("00000000-0000-0000-0000-000000000005"), 9 },
                    { new Guid("a9a9a9a9-a9a9-a9a9-a9a9-a9a9a9a9a9a9"), new Guid("00000000-0000-0000-0000-000000000006"), 6 },
                    { new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"), new Guid("00000000-0000-0000-0000-000000000006"), 7 },
                    { new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"), new Guid("00000000-0000-0000-0000-000000000006"), 8 },
                    { new Guid("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"), new Guid("00000000-0000-0000-0000-000000000006"), 9 },
                    { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("00000000-0000-0000-0000-000000000007"), 6 },
                    { new Guid("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"), new Guid("00000000-0000-0000-0000-000000000007"), 7 },
                    { new Guid("a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3"), new Guid("00000000-0000-0000-0000-000000000007"), 8 },
                    { new Guid("a4a4a4a4-a4a4-a4a4-a4a4-a4a4a4a4a4a4"), new Guid("00000000-0000-0000-0000-000000000007"), 9 },
                    { new Guid("a5a5a5a5-a5a5-a5a5-a5a5-a5a5a5a5a5a5"), new Guid("00000000-0000-0000-0000-000000000008"), 6 },
                    { new Guid("a6a6a6a6-a6a6-a6a6-a6a6-a6a6a6a6a6a6"), new Guid("00000000-0000-0000-0000-000000000008"), 7 },
                    { new Guid("a7a7a7a7-a7a7-a7a7-a7a7-a7a7a7a7a7a7"), new Guid("00000000-0000-0000-0000-000000000008"), 8 },
                    { new Guid("a8a8a8a8-a8a8-a8a8-a8a8-a8a8a8a8a8a8"), new Guid("00000000-0000-0000-0000-000000000008"), 9 },
                    { new Guid("a9a9a9a9-a9a9-a9a9-a9a9-a9a9a9a9a9a9"), new Guid("00000000-0000-0000-0000-000000000009"), 6 },
                    { new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"), new Guid("00000000-0000-0000-0000-000000000009"), 7 },
                    { new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"), new Guid("00000000-0000-0000-0000-000000000009"), 8 },
                    { new Guid("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"), new Guid("00000000-0000-0000-0000-000000000009"), 9 },
                    { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("00000000-0000-0000-0000-000000000010"), 6 },
                    { new Guid("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"), new Guid("00000000-0000-0000-0000-000000000010"), 7 },
                    { new Guid("a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3"), new Guid("00000000-0000-0000-0000-000000000010"), 8 },
                    { new Guid("a4a4a4a4-a4a4-a4a4-a4a4-a4a4a4a4a4a4"), new Guid("00000000-0000-0000-0000-000000000010"), 9 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProfesorPredmeti",
                keyColumns: new[] { "PredmetId", "ProfesorId" },
                keyValues: new object[] { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "ProfesorPredmeti",
                keyColumns: new[] { "PredmetId", "ProfesorId" },
                keyValues: new object[] { new Guid("a6a6a6a6-a6a6-a6a6-a6a6-a6a6a6a6a6a6"), new Guid("11111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "ProfesorPredmeti",
                keyColumns: new[] { "PredmetId", "ProfesorId" },
                keyValues: new object[] { new Guid("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"), new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "ProfesorPredmeti",
                keyColumns: new[] { "PredmetId", "ProfesorId" },
                keyValues: new object[] { new Guid("a7a7a7a7-a7a7-a7a7-a7a7-a7a7a7a7a7a7"), new Guid("22222222-2222-2222-2222-222222222222") });

            migrationBuilder.DeleteData(
                table: "ProfesorPredmeti",
                keyColumns: new[] { "PredmetId", "ProfesorId" },
                keyValues: new object[] { new Guid("a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "ProfesorPredmeti",
                keyColumns: new[] { "PredmetId", "ProfesorId" },
                keyValues: new object[] { new Guid("a8a8a8a8-a8a8-a8a8-a8a8-a8a8a8a8a8a8"), new Guid("33333333-3333-3333-3333-333333333333") });

            migrationBuilder.DeleteData(
                table: "ProfesorPredmeti",
                keyColumns: new[] { "PredmetId", "ProfesorId" },
                keyValues: new object[] { new Guid("a4a4a4a4-a4a4-a4a4-a4a4-a4a4a4a4a4a4"), new Guid("44444444-4444-4444-4444-444444444444") });

            migrationBuilder.DeleteData(
                table: "ProfesorPredmeti",
                keyColumns: new[] { "PredmetId", "ProfesorId" },
                keyValues: new object[] { new Guid("a5a5a5a5-a5a5-a5a5-a5a5-a5a5a5a5a5a5"), new Guid("55555555-5555-5555-5555-555555555555") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a4a4a4a4-a4a4-a4a4-a4a4-a4a4a4a4a4a4"), new Guid("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a5a5a5a5-a5a5-a5a5-a5a5-a5a5a5a5a5a5"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a6a6a6a6-a6a6-a6a6-a6a6-a6a6a6a6a6a6"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a7a7a7a7-a7a7-a7a7-a7a7-a7a7a7a7a7a7"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a8a8a8a8-a8a8-a8a8-a8a8-a8a8a8a8a8a8"), new Guid("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a9a9a9a9-a9a9-a9a9-a9a9-a9a9a9a9a9a9"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"), new Guid("00000000-0000-0000-0000-000000000003") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a4a4a4a4-a4a4-a4a4-a4a4-a4a4a4a4a4a4"), new Guid("00000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a5a5a5a5-a5a5-a5a5-a5a5-a5a5a5a5a5a5"), new Guid("00000000-0000-0000-0000-000000000005") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a6a6a6a6-a6a6-a6a6-a6a6-a6a6a6a6a6a6"), new Guid("00000000-0000-0000-0000-000000000005") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a7a7a7a7-a7a7-a7a7-a7a7-a7a7a7a7a7a7"), new Guid("00000000-0000-0000-0000-000000000005") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a8a8a8a8-a8a8-a8a8-a8a8-a8a8a8a8a8a8"), new Guid("00000000-0000-0000-0000-000000000005") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a9a9a9a9-a9a9-a9a9-a9a9-a9a9a9a9a9a9"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"), new Guid("00000000-0000-0000-0000-000000000006") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a4a4a4a4-a4a4-a4a4-a4a4-a4a4a4a4a4a4"), new Guid("00000000-0000-0000-0000-000000000007") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a5a5a5a5-a5a5-a5a5-a5a5-a5a5a5a5a5a5"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a6a6a6a6-a6a6-a6a6-a6a6-a6a6a6a6a6a6"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a7a7a7a7-a7a7-a7a7-a7a7-a7a7a7a7a7a7"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a8a8a8a8-a8a8-a8a8-a8a8-a8a8a8a8a8a8"), new Guid("00000000-0000-0000-0000-000000000008") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a9a9a9a9-a9a9-a9a9-a9a9-a9a9a9a9a9a9"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"), new Guid("00000000-0000-0000-0000-000000000009") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), new Guid("00000000-0000-0000-0000-000000000010") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"), new Guid("00000000-0000-0000-0000-000000000010") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3"), new Guid("00000000-0000-0000-0000-000000000010") });

            migrationBuilder.DeleteData(
                table: "StudentPredmeti",
                keyColumns: new[] { "PredmetId", "StudentId" },
                keyValues: new object[] { new Guid("a4a4a4a4-a4a4-a4a4-a4a4-a4a4a4a4a4a4"), new Guid("00000000-0000-0000-0000-000000000010") });

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "Id",
                keyValue: new Guid("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"));

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "Id",
                keyValue: new Guid("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"));

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "Id",
                keyValue: new Guid("a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3"));

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "Id",
                keyValue: new Guid("a4a4a4a4-a4a4-a4a4-a4a4-a4a4a4a4a4a4"));

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "Id",
                keyValue: new Guid("a5a5a5a5-a5a5-a5a5-a5a5-a5a5a5a5a5a5"));

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "Id",
                keyValue: new Guid("a6a6a6a6-a6a6-a6a6-a6a6-a6a6a6a6a6a6"));

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "Id",
                keyValue: new Guid("a7a7a7a7-a7a7-a7a7-a7a7-a7a7a7a7a7a7"));

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "Id",
                keyValue: new Guid("a8a8a8a8-a8a8-a8a8-a8a8-a8a8a8a8a8a8"));

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "Id",
                keyValue: new Guid("a9a9a9a9-a9a9-a9a9-a9a9-a9a9a9a9a9a9"));

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "Id",
                keyValue: new Guid("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"));

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "Id",
                keyValue: new Guid("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"));

            migrationBuilder.DeleteData(
                table: "Predmeti",
                keyColumn: "Id",
                keyValue: new Guid("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"));

            migrationBuilder.DeleteData(
                table: "Profesori",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Profesori",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Profesori",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Profesori",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Profesori",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Studenti",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"));

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Profesori");
        }
    }
}
