namespace PukiAPI.Models.DTO.PredmetDTOs
{
    public class PredmetDTO
    {

        public Guid Id { get; set; }
        public string Naziv { get; set; }
        public int ESPB { get; set; }
        public int? Ocena { get; set; }
    }
}
