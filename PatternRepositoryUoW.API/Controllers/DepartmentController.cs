using Microsoft.AspNetCore.Mvc;
using PatternRepositoryUoW.API.Data.Repositories;

namespace PatternRepositoryUoW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentRepository departmentRepository)
        {
            _logger = logger;
            _departmentRepository = departmentRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id /*,[FromServices] IDepartmentRepository _departmentRepository*/)
        {
            var departments = await _departmentRepository.GetByIdAsync(id);
            return Ok(departments);
        }
    }
}