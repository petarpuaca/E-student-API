using PukiAPI.Models.Domain;
using PukiAPI.Models.DTO;

namespace PukiAPI.Repositories
{
    public interface IStudentRepository
    {
       Task<List<StudentDto>> GetAllAsync(string? sortBy=null,bool isAscending=true,string? filterOn=null,string? query=null);
       Task <StudentDto?> GetByIdAsync(Guid id);

       Task<Student> CreateAsync(Student student);

       Task<Student?> UpdateAsync(Guid id, Student student);

        Task<Student?>DeleteAsync(Guid id);

        Task<StudentDto> GetStudentByIndex(string index);
    }
}
