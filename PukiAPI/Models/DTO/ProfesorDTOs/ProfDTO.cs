using PukiAPI.Models.Domain;
using PukiAPI.Models.DTO.PredmetDTOs;

namespace PukiAPI.Models.DTO.ProfesorDTOs
{
    public class ProfDTO
    {
        public Guid Id { get; set; }
        public string Ime { get; set; }

        public string Prezime { get; set; }
        public string Email { get; set; }

        public List<PredmetDTO> Predmeti { get; set; }

    }
}
