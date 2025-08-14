using Microsoft.EntityFrameworkCore;
using PukiAPI.Models.Domain;

namespace PukiAPI.Data
{
    public class PUKIDbContext : DbContext
    {
        public PUKIDbContext(DbContextOptions<PUKIDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
        public DbSet<Profesor> Profesori { get; set; }
        public DbSet<ProfesorPredmet> ProfesorPredmeti { get; set; }
        public DbSet<StudentPredmet> StudentPredmeti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        
            // Kompozitni ključevi
            modelBuilder.Entity<ProfesorPredmet>().HasKey(pp => new { pp.ProfesorId, pp.PredmetId });
            modelBuilder.Entity<StudentPredmet>().HasKey(sp => new { sp.StudentId, sp.PredmetId });

            // Profesori
            var profesori = new List<Profesor>
    {
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Ime = "Marko", Prezime = "Marković",Email="markomarkovic@gmail.com" },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000002"), Ime = "Ana", Prezime = "Anić",Email="anaanic@gmail.com" },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000003"), Ime = "Ivan", Prezime = "Ivanović",Email="ivanivanovic@gmail.com" },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000004"), Ime = "Jelena", Prezime = "Jelić",Email="jelenajelic@gmail.com" },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000005"), Ime = "Petar", Prezime = "Petrović",Email="petarpetrovic@gmail.com" },
    };
            modelBuilder.Entity<Profesor>().HasData(profesori);

            // Predmeti
            var predmeti = new List<Predmet>
    {
        new() { Id = Guid.Parse("a1a1a1a1-a1a1-a1a1-a1a1-a1a1a1a1a1a1"), Naziv = "Matematika" },
        new() { Id = Guid.Parse("a2a2a2a2-a2a2-a2a2-a2a2-a2a2a2a2a2a2"), Naziv = "Fizika" },
        new() { Id = Guid.Parse("a3a3a3a3-a3a3-a3a3-a3a3-a3a3a3a3a3a3"), Naziv = "Programiranje" },
        new() { Id = Guid.Parse("a4a4a4a4-a4a4-a4a4-a4a4-a4a4a4a4a4a4"), Naziv = "Baze Podataka" },
        new() { Id = Guid.Parse("a5a5a5a5-a5a5-a5a5-a5a5-a5a5a5a5a5a5"), Naziv = "Računarske mreže" },
        new() { Id = Guid.Parse("a6a6a6a6-a6a6-a6a6-a6a6-a6a6a6a6a6a6"), Naziv = "Web Programiranje" },
        new() { Id = Guid.Parse("a7a7a7a7-a7a7-a7a7-a7a7-a7a7a7a7a7a7"), Naziv = "Engleski jezik" },
        new() { Id = Guid.Parse("a8a8a8a8-a8a8-a8a8-a8a8-a8a8a8a8a8a8"), Naziv = "Softversko inženjerstvo" },
        new() { Id = Guid.Parse("a9a9a9a9-a9a9-a9a9-a9a9-a9a9a9a9a9a9"), Naziv = "Veštačka inteligencija" },
        new() { Id = Guid.Parse("b1b1b1b1-b1b1-b1b1-b1b1-b1b1b1b1b1b1"), Naziv = "Menadžment" },
        new() { Id = Guid.Parse("b2b2b2b2-b2b2-b2b2-b2b2-b2b2b2b2b2b2"), Naziv = "Marketing" },
        new() { Id = Guid.Parse("b3b3b3b3-b3b3-b3b3-b3b3-b3b3b3b3b3b3"), Naziv = "Statistika" },
    };
            modelBuilder.Entity<Predmet>().HasData(predmeti);

            // Studenti
            var studenti = new List<Student>
    {
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000010"), Ime = "Nikola", Prezime = "Nikolić", Smer = "IT", Index = "2021/1001" },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000011"), Ime = "Milica", Prezime = "Jovanović", Smer = "Menadzment", Index = "2021/1002" },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000012"), Ime = "Stefan", Prezime = "Petrović", Smer = "IT", Index = "2021/1003" },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000013"), Ime = "Jovana", Prezime = "Milić", Smer = "Menadzment", Index = "2021/1004" },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000014"), Ime = "Aleksandar", Prezime = "Pavlović", Smer = "IT", Index = "2021/1005" },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000015"), Ime = "Sara", Prezime = "Stojanović", Smer = "Menadzment", Index = "2021/1006" },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000016"), Ime = "Luka", Prezime = "Ilić", Smer = "IT", Index = "2021/1007" },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000017"), Ime = "Marija", Prezime = "Kostić", Smer = "Menadzment", Index = "2021/1008" },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000018"), Ime = "Ognjen", Prezime = "Đorđević", Smer = "IT", Index = "2021/1009" },
        new() { Id = Guid.Parse("00000000-0000-0000-0000-000000000019"), Ime = "Teodora", Prezime = "Radić", Smer = "Menadzment", Index = "2021/1010" },
    };
            modelBuilder.Entity<Student>().HasData(studenti);

            // Veze: StudentPredmet
            var studentPredmeti = new List<StudentPredmet>();
            int ocena = 6;
            int predmetCounter = 0;
            foreach (var student in studenti)
            {
                for (int i = 0; i < 4; i++)
                {
                    var predmet = predmeti[predmetCounter % predmeti.Count];
                    studentPredmeti.Add(new StudentPredmet
                    {
                        StudentId = student.Id,
                        PredmetId = predmet.Id,
                        Ocena = ocena++
                    });
                    if (ocena > 10) ocena = 6;
                    predmetCounter++;
                }
            }
            modelBuilder.Entity<StudentPredmet>().HasData(studentPredmeti);

            // Veze: ProfesorPredmet
            var profesorPredmeti = new List<ProfesorPredmet>();
            predmetCounter = 0;
            foreach (var profesor in profesori)
            {
                for (int i = 0; i < 3; i++)
                {
                    var predmet = predmeti[predmetCounter % predmeti.Count];
                    profesorPredmeti.Add(new ProfesorPredmet
                    {
                        ProfesorId = profesor.Id,
                        PredmetId = predmet.Id
                    });
                    predmetCounter++;
                }
            }
            modelBuilder.Entity<ProfesorPredmet>().HasData(profesorPredmeti);

            base.OnModelCreating(modelBuilder);
        }

    }
}

