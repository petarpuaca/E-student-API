using Microsoft.EntityFrameworkCore;
using PukiAPI.Data;
using PukiAPI.Models.Domain;

namespace PukiAPI.Repositories.StudentPredmetRepository
{
    public class SQLStudentPredmet : IStudentPredmetRepo
    {
        private readonly PUKIDbContext dbContext;

        public SQLStudentPredmet(PUKIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<StudentPredmet> AddStudentPredmet(Guid predmetId, Guid studentId)
        {
            var student=await dbContext.Studenti.FirstOrDefaultAsync(x=>x.Id==studentId);
            if (student == null)
            {
                return null;
            }
            var predmet= await dbContext.Predmeti.FirstOrDefaultAsync(x=>x.Id == predmetId);
            if (predmet == null)
            {
                return null;
            }
            StudentPredmet sp = new StudentPredmet()
            {
                Ocena = 5,
                PredmetId = predmetId,
                StudentId = studentId,
                Predmet = predmet,
                Student = student,
            };
            await dbContext.AddAsync(sp);
            await dbContext.SaveChangesAsync();
            return sp;



        }
    }
}
