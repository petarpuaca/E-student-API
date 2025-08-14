using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PukiAPI.Models.Domain;
using PukiAPI.Models.DTO.ProfesorPredmetDTO;
using PukiAPI.Repositories.ProfesorPredmetRepo;

namespace PukiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorPredmetController : ControllerBase
    {
        private readonly IProfesorPredmetRepo profesorPredmetRepo;

        public ProfesorPredmetController(IProfesorPredmetRepo profesorPredmetRepo)
        {
            this.profesorPredmetRepo = profesorPredmetRepo;
        }


        [HttpPost]
        [Route("{idProfesor:guid},{idPredmet:guid}")]

        public async Task<IActionResult> addProfesorPredmet([FromRoute]Guid idProfesor, [FromRoute]Guid idPredmet)
        {
            var profesorPredmet=await profesorPredmetRepo.AddPredmet(idProfesor,idPredmet);
            if(profesorPredmet == null)
            {
                return NotFound();
            }
            ProfesorPredmetDTO profesorPredmetDTO = new ProfesorPredmetDTO()
            {
                ProfesorId = idProfesor,

                PredmetId = idPredmet,
            };
        
        return Ok(profesorPredmetDTO);
        }
    
    };
}
