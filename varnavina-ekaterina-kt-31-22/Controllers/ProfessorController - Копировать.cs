using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using varnavina_ekaterina_kt_31_22.Interfaces.ProfessorsInterfaces;
using varnavina_ekaterina_kt_31_22.Models;

namespace varnavina_ekaterina_kt_31_22.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;

        public ProfessorController(ISubjectService subjectService, ITeacherService teacherService)
        {
            _subjectService = subjectService;
            _teacherService = teacherService;
        }

        // GET api/professor/teachers
        [HttpGet("GetAllTeachers")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAllAsync();
            return Ok(teachers);
        }

        // GET api/professor/teachers/{id}
        [HttpGet("GetTeacherById/{id}")]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);
            if (teacher == null)
                return NotFound();

            return Ok(teacher);
        }

        // POST api/professor/teachers
        [HttpPost("AddTeacher")]
        public async Task<IActionResult> AddTeacher([FromBody] Professor teacher)
        {
            var added = await _teacherService.AddAsync(teacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = added.TeacherId }, added);
        }

        // PUT api/professor/teachers/{id}
        [HttpPut("UpdateTeacher/{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] Professor teacher)
        {
            if (id != teacher.TeacherId)
                return BadRequest("ID mismatch");

            var updated = await _teacherService.UpdateAsync(teacher);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE api/professor/teachers/{id}
        [HttpDelete("SoftDeleteTeacher/{id}")]
        public async Task<IActionResult> SoftDeleteTeacher(int id)
        {
            var result = await _teacherService.SoftDeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }       
        [HttpGet("error")]
        public IActionResult TriggerError()
        {
            throw new Exception("Проверка Middlewares");
        }
    }

    // Класс фильтра для дисциплин
    public class DisciplineFilter
    {
        public int? TeacherId { get; set; }
        public int? MinLoad { get; set; }
        public int? MaxLoad { get; set; }
    }

}
