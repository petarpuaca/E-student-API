namespace PukiAPI.Models.Domain
{
    public class Predmet
    {
        public Guid Id { get; set; }
        public string Naziv { get; set; }

        public int ESPB { get; set; }

        public virtual ICollection<ProfesorPredmet> ProfesorPredmeti { get; set; }
        public virtual ICollection<StudentPredmet> StudentPredmeti { get; set; }
    }
}