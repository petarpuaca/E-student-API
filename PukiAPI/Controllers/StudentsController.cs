using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PukiAPI.CustomActionFilters;
using PukiAPI.Data;
using PukiAPI.Models.Domain;
using PukiAPI.Models.DTO;
using PukiAPI.Models.DTO.ProfesorDTOs;
using PukiAPI.Repositories;

namespace PukiAPI.Controllers
{
    //https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //GET:https://localhost:portnumber/api/students
        private readonly PUKIDbContext dbContext;
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentsController(PUKIDbContext dbContext,IStudentRepository studentRepository,IMapper mapper )
        {
            this.dbContext = dbContext;
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        //GET ALL Students
        //api/students?sortBy=Naziv&isAscending
        public async Task<IActionResult> GetAll([FromQuery] string? sortBy,bool? isAscending, [FromQuery] string? filterOn, [FromQuery]string?query)
        {
            //Get Data from database- Domain Models
             var students = await studentRepository.GetAllAsync(null, true, filterOn, query);

            //var studentsDto= mapper.Map<List<StudentDto>>(students);

            //Return DTOs
            return Ok(students);

        }

        //GET SINGLE Student(by id)
        //../students/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var student=dbContext.Studenti.Find(id);
            var student = await studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound();//vraca 404
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] AddStudentDto addStudentDto)
        {
            
            if(ModelState.IsValid)
            {


           var studentModel=mapper.Map<Student>(addStudentDto);
           studentModel= await studentRepository.CreateAsync(studentModel);
            
            
            var studentDto=mapper.Map<StudentDto>(studentModel);
            return CreatedAtAction(nameof(GetById), new { id = studentModel.Id }, studentDto);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModelAtribute]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, [FromBody] UpdateStudentDto updateStudentDto)
        {
           


            var student=mapper.Map<Student>(updateStudentDto);

            var studentDomain = await studentRepository.UpdateAsync(id,student);
            if (studentDomain == null)
            {
                return NotFound();
            }
            
            await dbContext.SaveChangesAsync();

            

              var studentDto=mapper.Map<StudentDto>(studentDomain);


            return Ok(studentDto);
            
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var studentDomain= await studentRepository.DeleteAsync(id);
            if (studentDomain == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("{*index}")]
        public async Task<IActionResult> GetStudentByIndex([FromRoute] string index)
        {
            index = WebUtility.UrlDecode(index);
            var student=await studentRepository.GetStudentByIndex(index);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        
    }
}
