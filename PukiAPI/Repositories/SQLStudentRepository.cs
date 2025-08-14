using Microsoft.EntityFrameworkCore;
using PukiAPI.Data;
using PukiAPI.Models.Domain;
using PukiAPI.Models.DTO;
using PukiAPI.Models.DTO.PredmetDTOs;

namespace PukiAPI.Repositories
{
    public class SQLStudentRepository : IStudentRepository
    {

        private readonly PUKIDbContext dbContext;
        public SQLStudentRepository(PUKIDbContext dbContext)
        {
            this.dbContext=dbContext;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await dbContext.Studenti.AddAsync(student);
            dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student?> DeleteAsync(Guid id)
        {
           var student= dbContext.Studenti.FirstOrDefault(x => x.Id==id);  
        if (student==null)
            {
                return null;
            }
         dbContext.Studenti.Remove(student);
         await dbContext.SaveChangesAsync();
           return student;

        }

        public async Task<List<StudentDto>> GetAllAsync(string? sortBy=null,bool isAscending=true,string? filterOn=null,string?query=null)
        {
          var studentsQuery=dbContext.Studenti.Include(x => x.StudentPredmeti).ThenInclude(x => x.Predmet).AsQueryable();
            //var students=await dbContext.Studenti.Include(x=>x.StudentPredmeti).ThenInclude(x=>x.Predmet).ToListAsync();

            if (filterOn != null)
            {
                switch (filterOn) {
                    case "Smer":
                        studentsQuery = studentsQuery.Where(x => x.Smer == query);
                        break;
                    case "Index":
                        studentsQuery = studentsQuery.Where(x=>x.Index==query);
                        break;
                    case "Ime":
                        studentsQuery = studentsQuery.Where(x => x.Ime == query);
                        break;
                    case "Prezime":
                        studentsQuery = studentsQuery.Where(x => x.Prezime == query);
                        break;
                }
            }
             var students = await studentsQuery.ToListAsync();
            var studentDTO = students.Select(s => new StudentDto()
            {
                Id = s.Id,
                Ime = s.Ime,
                Prezime = s.Prezime,
                Index = s.Index,
                Smer=s.Smer,
                Predmeti=s.StudentPredmeti.Select(sp=> new PredmetDTO()
                {
                    Id=sp.PredmetId,
                    Naziv=sp.Predmet.Naziv,
                    Ocena=sp.Ocena
                }).ToList(),
            }).ToList();
            return studentDTO;
        }

        public async Task<StudentDto?> GetByIdAsync(Guid id)
        {
            var student= await dbContext.Studenti.Include(x=>x.StudentPredmeti).ThenInclude(x=>x.Predmet).FirstOrDefaultAsync(x=>x.Id==id);
            if(student==null)
            {
                return null;
            }
            //
            var studentDTO = new StudentDto()
            {
                Id = student.Id,
                Ime = student.Ime,
                Prezime = student.Prezime,
                Index = student.Index,
                Smer = student.Smer,
                Predmeti = student.StudentPredmeti.Select(sp => new PredmetDTO()
                {
                    Id = sp.PredmetId,
                    Naziv = sp.Predmet.Naziv,
                    Ocena = sp.Ocena
                }).ToList()

            };
            return studentDTO;
        }

        public async Task<StudentDto> GetStudentByIndex(string index)
        {
            var student= await dbContext.Studenti.Include(x=>x.StudentPredmeti).ThenInclude(x=>x.Predmet).FirstOrDefaultAsync(x=>x.Index==index);
            if (student == null)
            {
                return null;
            }
            var studentDTO = new StudentDto()
            {
                Id = student.Id,
                Ime = student.Ime,
                Prezime = student.Prezime,
                Index = student.Index,
                Smer = student.Smer,
                Predmeti = student.StudentPredmeti.Select(sp => new PredmetDTO()
                {
                    Id = sp.PredmetId,
                    Naziv = sp.Predmet.Naziv,
                    Ocena = sp.Ocena
                }).ToList(),
            };
            return studentDTO;
        }

        public async Task<Student?> UpdateAsync(Guid id, Student student)
        {
            var studentDomain=await dbContext.Studenti.FirstOrDefaultAsync(x=>x.Id==id);
            if (studentDomain == null)
            {
                return null;
            };
            
            studentDomain.Smer=student.Smer;
            studentDomain.Ime=student.Ime;
            studentDomain.Prezime=student.Prezime;
            studentDomain.Index=student.Index;
            await dbContext.SaveChangesAsync();
            return studentDomain;
        }

        //async Task<Student?> IStudentRepository.GetByIdAsync(Guid id)
        //{
        //     return await dbContext.Studenti.FirstOrDefaultAsync(x=>x.Id == id);
        //}


    }
}
