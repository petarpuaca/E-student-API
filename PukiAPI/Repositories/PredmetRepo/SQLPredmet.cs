using Microsoft.EntityFrameworkCore;
using PukiAPI.Data;
using PukiAPI.Models.Domain;
using PukiAPI.Models.DTO.PredmetDTOs;

namespace PukiAPI.Repositories.PredmetRepo
{
    public class SQLPredmet : IPredmetRepo
    {
        private readonly PUKIDbContext dbContext;

        public SQLPredmet(PUKIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Predmet> CreatePredmet(Predmet predmet)
        {
            await dbContext.Predmeti.AddAsync(predmet);
            await dbContext.SaveChangesAsync();
            return predmet;
            
        }

        public async Task<Predmet> DeletePredmet(Guid id)
        {
            var predmet=await dbContext.Predmeti.FirstOrDefaultAsync(x=>x.Id==id);
            if (predmet == null)
            {
                return null;
            }
            dbContext.Remove(predmet);
            await dbContext.SaveChangesAsync();
            return predmet;
        }

        public async Task<(List<GetAllPredmetDTO> predmeti, int totalCount)> GetAll(
    string? filterOn = null,
    string? filterQuery = null,
    int page = 1,
    int pageSize = 10)
        {
            var query = dbContext.Predmeti
                .Include(p => p.ProfesorPredmeti).ThenInclude(pp => pp.Profesor)
                .Include(p => p.StudentPredmeti)
                .AsQueryable();

            // Ako imaš filtere možeš ih dodati ovde (opciono)
            if (!string.IsNullOrWhiteSpace(filterOn) && !string.IsNullOrWhiteSpace(filterQuery))
            {
                if (filterOn == "Naziv")
                    query = query.Where(p => p.Naziv.Contains(filterQuery));
                // Dodaj dalje po potrebi...
            }

            // Ukupan broj pre paginacije
            var totalCount = await query.CountAsync();

            // Paginate
            var predmeti = await query
                .OrderBy(p => p.Naziv) // (ili šta želiš)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new GetAllPredmetDTO
                {
                    Id = p.Id,
                    Naziv = p.Naziv,
                    ESPB = p.ESPB,
                    Profesori = p.ProfesorPredmeti
                                .Select(pp => pp.Profesor.Ime + " " + pp.Profesor.Prezime)
                                .ToList(),
                    BrojStudenata = p.StudentPredmeti.Count
                })
                .ToListAsync();

            return (predmeti, totalCount);
        }

        public async Task<List<Predmet>> GetAllPredmeti()
        {
            var predmeti=await dbContext.Predmeti.ToListAsync();
            if (predmeti == null)
            {
                return null;
            }
            return predmeti;

        }

        public async Task<Predmet> GetById(Guid id)
        {
            var predmet=await dbContext.Predmeti.FirstOrDefaultAsync(x=>x.Id==id);
            if(predmet == null)
            {
                return null;
            }
            return predmet;
        }

        public async Task<Predmet> UpdatePredmet(Predmet predmet, Guid id)
        {
            var predmetDomain =await dbContext.Predmeti.FirstOrDefaultAsync(x=>x.Id == id);
            if(predmet == null)
            {
                return null;
            }
            predmetDomain.Naziv=predmet.Naziv;
            predmetDomain.ESPB=predmet.ESPB;
            await dbContext.SaveChangesAsync();
            return predmetDomain;
        }
    }
}
