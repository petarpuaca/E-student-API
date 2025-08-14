namespace PukiAPI.Models.Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string Index { get; set; }

        public string Smer { get; set; }

        public virtual ICollection<StudentPredmet> StudentPredmeti { get; set; }
    }
}
