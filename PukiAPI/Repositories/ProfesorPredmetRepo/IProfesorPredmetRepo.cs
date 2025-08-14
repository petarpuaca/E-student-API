using PukiAPI.Models.Domain;

namespace PukiAPI.Repositories.ProfesorPredmetRepo
{
    public interface IProfesorPredmetRepo
    {
        Task<ProfesorPredmet> AddPredmet(Guid idProfesor,Guid idPredmet);
    }
}
