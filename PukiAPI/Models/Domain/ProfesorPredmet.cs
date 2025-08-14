namespace PukiAPI.Models.Domain
{
    public class ProfesorPredmet
    {
        public Guid ProfesorId { get; set; }
        public virtual Profesor Profesor { get; set; }

        public Guid PredmetId { get; set; }
        public virtual Predmet Predmet { get; set; }
    }
}