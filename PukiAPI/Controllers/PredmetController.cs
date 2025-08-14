using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PukiAPI.Data;
using PukiAPI.Models.Domain;
using PukiAPI.Models.DTO.PredmetDTOs;
using PukiAPI.Repositories.PredmetRepo;

namespace PukiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredmetController : ControllerBase
    {

        private readonly IMapper mapper;
        private readonly IPredmetRepo predmetRepo;

        public PredmetController(IMapper mapper, IPredmetRepo predmetRepo)
        {

            this.mapper = mapper;
            this.predmetRepo = predmetRepo;
        }
        //GET: /api/walks?filterOn=Name&filterQuery=Track
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]string? filterOn, [FromQuery] string? filterQuery, int page = 1,
    int pageSize = 10)
        {
            var (predmeti, totalCount) = await predmetRepo.GetAll(filterOn, filterQuery, page, pageSize);

            return Ok(new
            {
                totalCount,
                totalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                page,
                pageSize,
                predmeti
            });
        }

        [HttpGet("obicna")]
        public async Task<IActionResult> GetAllPredmeti()
        {
            var predmeti=await predmetRepo.GetAllPredmeti();
            if (predmeti == null)
            {
                return BadRequest();
            }
            return Ok(predmeti);
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetPredmet([FromRoute] Guid id)
        {
            var predmet = await predmetRepo.GetById(id);
            if (predmet == null)
            {
                return NotFound();
            }
            return Ok(predmet);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePredmet([FromBody] AddPredmetDTO addPredmetDTO)
        {
            var predmetDomain = mapper.Map<Predmet>(addPredmetDTO);
            predmetDomain.Id = Guid.NewGuid();
            predmetDomain = await predmetRepo.CreatePredmet(predmetDomain);
            if (predmetDomain == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetPredmet), new { id = predmetDomain.Id }, mapper.Map<PredmetDTO>(predmetDomain));

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var predmet = await predmetRepo.DeletePredmet(id);
            if (predmet == null)
            {
                return NotFound();
            }
            return Ok(predmet);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePredmet([FromBody] AddPredmetDTO addPredmetDTO, [FromRoute] Guid id)
        {
            var predmet = mapper.Map<Predmet>(addPredmetDTO);
            var predmetDomain = await predmetRepo.UpdatePredmet(predmet, id);
            if (predmetDomain == null)
            {
                return BadRequest();

            }
            return Ok(mapper.Map<PredmetDTO>(predmetDomain));
        }

    }
}
