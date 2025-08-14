using PukiAPI.Models.Domain;

namespace PukiAPI.Repositories.StudentPredmetRepository
{
    public interface IStudentPredmetRepo
    {
        Task<StudentPredmet> AddStudentPredmet(Guid Predmet, Guid Student);
    }
}
