using AutoMapper;
using PukiAPI.Models.Domain;
using PukiAPI.Models.DTO;
using PukiAPI.Models.DTO.PredmetDTOs;
using PukiAPI.Models.DTO.ProfesorDTOs;

namespace PukiAPI.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student,AddStudentDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();
            CreateMap<Profesor,ProfDTO>().ReverseMap();
            CreateMap<Predmet,PredmetDTO>().ReverseMap();
            CreateMap<Profesor,AddProfDTO>().ReverseMap();
            CreateMap<Predmet,AddPredmetDTO>().ReverseMap();
        }
    }
}
