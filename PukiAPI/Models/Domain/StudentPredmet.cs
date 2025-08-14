using System.ComponentModel.DataAnnotations;

namespace PukiAPI.Models.Domain
{
    public class StudentPredmet
    {
        public Guid StudentId { get; set; }
        public virtual Student Student { get; set; }

        public Guid PredmetId { get; set; }
        public virtual Predmet Predmet { get; set; }

        [Range(5, 10)]
        public int? Ocena { get; set; }
    }
}