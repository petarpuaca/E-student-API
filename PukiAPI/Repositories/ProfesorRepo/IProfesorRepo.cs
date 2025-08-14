using PukiAPI.Models.Domain;
using PukiAPI.Models.DTO.ProfesorDTOs;
namespace PukiAPI.Repositories.ProfesorRepo

{
    public interface IProfesorRepo
    {
        public Task<List<ProfDTO>> GetAllProfesor(string?filterOn=null,string?query=null);
        public Task<ProfDTO> GetProfesor(Guid id);

        public Task<Profesor>CreateProfesor(Profesor profesor);

        public Task<Profesor> DeleteProfesor(Guid id);

        public Task<Profesor> UpdateProfesor(Profesor profesor,Guid id);
        
    }
}
