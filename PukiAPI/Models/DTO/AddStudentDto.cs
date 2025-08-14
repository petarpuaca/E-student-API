using System.ComponentModel.DataAnnotations;

namespace PukiAPI.Models.DTO
{
    public class AddStudentDto
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        [MinLength(9,ErrorMessage ="Index mora da ima minimum 9 karaktera")]
        [RegularExpression(@"^\d{4}/\d{4}$", ErrorMessage = "Index mora biti u formatu 'YYYY/NNNN' (npr. 2021/0064)")]
        public string Index { get; set; }
        [Required]
        [RegularExpression("^(IT|Menadzment)$", ErrorMessage = "Smer mora biti 'IT' ili 'Menadzment'")]
        public string Smer { get; set; }
    }
}
