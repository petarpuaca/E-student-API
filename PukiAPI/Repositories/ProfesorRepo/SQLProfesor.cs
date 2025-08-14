using Microsoft.EntityFrameworkCore;
using PukiAPI.Data;
using PukiAPI.Models.Domain;
using PukiAPI.Models.DTO.PredmetDTOs;
using PukiAPI.Models.DTO.ProfesorDTOs;

namespace PukiAPI.Repositories.ProfesorRepo
{
    public class SQLProfesor : IProfesorRepo
    {
        private readonly PUKIDbContext dbContext;

        public SQLProfesor(PUKIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Profesor> CreateProfesor(Profesor profesor)
        {
            await dbContext.AddAsync(profesor);
            await dbContext.SaveChangesAsync();
            return profesor;
        }

        public async Task<Profesor> DeleteProfesor(Guid id)
        {
            var profesor=await dbContext.Profesori.FirstOrDefaultAsync(x=>x.Id==id);
            if (profesor == null)
            {
                return null;
            }
            dbContext.Remove(profesor);
            await dbContext.SaveChangesAsync();
            return profesor;
        }

        public async Task<List<ProfDTO>> GetAllProfesor(string? filterOn = null, string? query = null)
        {
            var profesorsQuery= dbContext.Profesori.Include(x => x.ProfesorPredmeti).ThenInclude(x => x.Predmet).AsQueryable();

            if (filterOn != null && query!= null)
            {
                switch(filterOn)
                {
                    case "Ime":
                        profesorsQuery = profesorsQuery.Where(x=>x.Ime==query);
                        break;
                    case "Prezime":
                        profesorsQuery = profesorsQuery.Where(x => x.Prezime == query);
                        break;
                    case "Email":
                        profesorsQuery = profesorsQuery.Where(x => x.Email == query);
                        break;
                }
            };
            var profesors=await profesorsQuery.ToListAsync();

            var proDTO= profesors.Select(p=> new ProfDTO()
            {
                Email = p.Email,
                Id = p.Id,
                Ime = p.Ime,
                Prezime = p.Prezime,
                Predmeti=p.ProfesorPredmeti.Select(p=> new PredmetDTO()
                {
                    Id=p.PredmetId,
                    Naziv=p.Predmet.Naziv
                }).ToList()
            }).ToList();
            return proDTO;
        }

        public async Task<ProfDTO> GetProfesor(Guid id)
        {
            var profesor=await dbContext.Profesori.Include(x=>x.ProfesorPredmeti).ThenInclude(x=>x.Predmet).FirstOrDefaultAsync(x => x.Id == id);
            if(profesor == null)
            {
                return null;
            }
            var profesorDTO = new ProfDTO()
            {
                Email = profesor.Email,
                Id = profesor.Id,
                Ime = profesor.Ime,
                Prezime = profesor.Prezime,
                Predmeti = profesor.ProfesorPredmeti.Select(pp => new PredmetDTO()
                {
                    Id = pp.PredmetId,
                    Naziv = pp.Predmet.Naziv

                }).ToList()
            };
            return profesorDTO;
        }

        public async Task<Profesor> UpdateProfesor(Profesor profesor, Guid id)
        {
            var profesorUpadate=await dbContext.Profesori.FirstOrDefaultAsync(x => x.Id==id);
            if( profesorUpadate == null)
            {
                return null;
            };
            profesorUpadate.Ime=profesor.Ime;
            profesorUpadate.Prezime=profesor.Prezime;
            profesorUpadate.Email=profesor.Email;
            await dbContext.SaveChangesAsync();
            return profesorUpadate;
        }
    }
}
