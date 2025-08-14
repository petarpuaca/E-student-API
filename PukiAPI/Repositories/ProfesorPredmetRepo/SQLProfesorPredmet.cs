using Microsoft.EntityFrameworkCore;
using PukiAPI.Data;
using PukiAPI.Models.Domain;

namespace PukiAPI.Repositories.ProfesorPredmetRepo
{
    public class SQLProfesorPredmet : IProfesorPredmetRepo
    {
        private readonly PUKIDbContext dbContext;

        public SQLProfesorPredmet(PUKIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ProfesorPredmet> AddPredmet(Guid idProfesor, Guid idPredmet)
        {
            var profesor= await dbContext.Profesori.FirstOrDefaultAsync(x=>x.Id == idProfesor);
            if(profesor == null)
            {
                return null;
            }
            var predmet=await dbContext.Predmeti.FirstOrDefaultAsync(x=>x.Id==idPredmet);
            if(predmet == null)
            {
                return null;
            }
            ProfesorPredmet profesorPredmet = new ProfesorPredmet()
            {
                PredmetId = idPredmet,
                Predmet = predmet,
                Profesor = profesor,
                ProfesorId = idProfesor
            };
            await dbContext.AddAsync(profesorPredmet);
            await dbContext.SaveChangesAsync();
            return profesorPredmet;
        }
    }
}
