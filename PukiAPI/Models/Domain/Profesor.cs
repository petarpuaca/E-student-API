namespace PukiAPI.Models.Domain
{
    public class Profesor
    {
        public Guid Id { get; set; }
        public string Ime { get; set; }

        public string Prezime {  get; set; }    
        public string Email { get; set; }

        public virtual ICollection<ProfesorPredmet> ProfesorPredmeti { get; set; }
    }
}