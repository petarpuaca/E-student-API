using PukiAPI.Models.Domain;
using PukiAPI.Models.DTO.PredmetDTOs;

namespace PukiAPI.Repositories.PredmetRepo
{
    public interface IPredmetRepo
    {
        public Task<(List<GetAllPredmetDTO> predmeti, int totalCount)> GetAll(string? filterOn=null,string? filterQuery=null, int page = 1,
    int pageSize = 10);
        public Task<Predmet> GetById(Guid id);

        public Task<Predmet> CreatePredmet(Predmet predmet);

        public Task<Predmet> UpdatePredmet(Predmet predmet,Guid id);

        public Task<Predmet> DeletePredmet(Guid id);

        public Task<List<Predmet>> GetAllPredmeti();
    }
}
