using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PukiAPI.Data;
using PukiAPI.Models.Domain;
using PukiAPI.Models.DTO;
using PukiAPI.Models.DTO.ProfesorDTOs;
using PukiAPI.Repositories.ProfesorRepo;

namespace PukiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProfesorController : ControllerBase
    {
 
        private readonly IProfesorRepo profesorRepo;
        private readonly IMapper mapper;

        public ProfesorController(IProfesorRepo profesorRepo,IMapper mapper)
        {
            
            this.profesorRepo = profesorRepo;
            this.mapper = mapper;
        }

        [HttpGet]
      
        public async Task<IActionResult> GetAll([FromQuery]string? filterOn = null, [FromQuery] string? query=null)
        {
            var profesorsDomain = await profesorRepo.GetAllProfesor(filterOn,query);
            if(profesorsDomain == null)
            {
                return NotFound();
            }
            return Ok(profesorsDomain);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult>GetProfesor([FromRoute] Guid id)
        {
            var profesor=await profesorRepo.GetProfesor(id);
            if(profesor == null)
            {
                return NotFound(); 
            }
            return Ok(profesor);
        }
        [HttpPost]
        //[Authorize(Roles ="Writer ")]
        public async Task<IActionResult> CreateProfesor([FromBody]AddProfDTO AddprofDTO)
        {
            var profesorDomain=mapper.Map<Profesor>(AddprofDTO);
            profesorDomain.Id=Guid.NewGuid();
            profesorDomain=await profesorRepo.CreateProfesor(profesorDomain);
            var profesorDTO = mapper.Map<ProfDTO>(profesorDomain);
            return CreatedAtAction(nameof(GetProfesor), new { id = profesorDomain.Id },profesorDTO);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles ="Writer")]
        public async Task<IActionResult>DeleteProfesor([FromRoute]Guid id)
        {
            var profesor=await profesorRepo.DeleteProfesor(id);
            if(profesor == null)
            {
                return NotFound();
            }
            return Ok(profesor);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateProfesor([FromBody] AddProfDTO AddprofDTO, [FromRoute] Guid id)
        {
            var profesorDomain = mapper.Map<Profesor>(AddprofDTO);
            var profesorUpdate = await profesorRepo.UpdateProfesor(profesorDomain, id);
            if (profesorUpdate == null)
            {
                return NotFound();
            }
            return Ok(profesorUpdate);
        }

    }
}
