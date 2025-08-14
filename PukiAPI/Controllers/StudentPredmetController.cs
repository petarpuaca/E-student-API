using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PukiAPI.Models.DTO.StudentPredmetDTOs;
using PukiAPI.Repositories.StudentPredmetRepository;

namespace PukiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentPredmetController : ControllerBase
    {
        private readonly IStudentPredmetRepo studentPredmetRepo;

        public StudentPredmetController(IStudentPredmetRepo studentPredmetRepo)
        {
            this.studentPredmetRepo = studentPredmetRepo;
        }

        [HttpPost]
        [Route("{studentId:guid},{predmetId:guid}")]
        public async Task<IActionResult> AddStudentPredmet([FromRoute] Guid studentId, [FromRoute] Guid predmetId)
        {
            var studentPredmet = await studentPredmetRepo.AddStudentPredmet(predmetId, studentId);
            if (studentPredmet == null)
            {
                return BadRequest();
            }
            return Ok(new StudentPredmetDTO()
            {
                PredmetId = studentPredmet.PredmetId,
                StudentId = studentPredmet.StudentId,
                
            });
        }
    }
}
