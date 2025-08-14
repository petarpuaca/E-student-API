namespace PukiAPI.Models.DTO.PredmetDTOs
{
    public class GetAllPredmetDTO
    {
        
            public Guid Id { get; set; }
            public string Naziv { get; set; }
            public int ESPB { get; set; }
            public List<string> Profesori { get; set; }
            public int BrojStudenata { get; set; }
        

    }
}
