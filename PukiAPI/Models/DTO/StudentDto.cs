using PukiAPI.Models.Domain;
using PukiAPI.Models.DTO.PredmetDTOs;

namespace PukiAPI.Models.DTO
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Index { get; set; }
        public string Smer { get; set; }
        public List<PredmetDTO> Predmeti { get; set; }
    }
}
