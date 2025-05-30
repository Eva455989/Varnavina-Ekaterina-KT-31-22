using Microsoft.AspNetCore.Mvc;
using varnavina_ekaterina_kt_31_22.Interfaces.ProfessorsInterfaces;
using varnavina_ekaterina_kt_31_22.Models;

namespace varnavina_ekaterina_kt_31_22.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisciplineController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;

        public DisciplineController(ISubjectService subjectService, ITeacherService teacherService)
        {
            _subjectService = subjectService;
            _teacherService = teacherService;
        }


        // POST api/professor/disciplines/filter
        [HttpPost("disciplines/filter")]
        public async Task<IActionResult> GetDisciplinesFiltered([FromBody] DisciplineFilter filter)
        {
            var disciplines = await _subjectService.GetDisciplinesFilteredAsync(filter.TeacherId, filter.MinLoad, filter.MaxLoad);
            return Ok(disciplines);
        }

        [HttpGet("error")]
        public IActionResult TriggerError()
        {
            throw new Exception("Проверка Middlewares");
        }
        // Класс фильтра для дисциплин
        public class DisciplineFilter
        {
            public int? TeacherId { get; set; }
            public int? MinLoad { get; set; }
            public int? MaxLoad { get; set; }
        }
    }
}



