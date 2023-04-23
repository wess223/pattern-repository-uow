using Microsoft.AspNetCore.Mvc;
using PatternRepositoryUoW.API.Data;
using PatternRepositoryUoW.API.Data.Repositories;
using PatternRepositoryUoW.API.Domain;

namespace PatternRepositoryUoW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        /*private readonly IDepartmentRepository _departmentRepository;*/
        private readonly IUnitOfWork _uow;

        public DepartmentController(ILogger<DepartmentController> logger, /*IDepartmentRepository departmentRepository,*/ IUnitOfWork uow)
        {
            _logger = logger;
            //_departmentRepository = departmentRepository;
            _uow = uow;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id /*,[FromServices] IDepartmentRepository _departmentRepository*/)
        {
            //var departments = await _departmentRepository.GetByIdAsync(id);
            var departments = await _uow.DepartmentRepository.GetByIdAsync(id);
            return Ok(departments);
        }

        [HttpPost]
        public IActionResult CreateDepartment(Department department)
        {
            //_departmentRepository.Add(department);
            _uow.DepartmentRepository.Add(department);

            //var saved = _departmentRepository.Save();

            _uow.Commit(); //SRP: Principio da responsabilidade unica. 05:23

            return Ok(department);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveDepartment(int id)
        {
            var department = await _uow.DepartmentRepository.GetByIdAsync(id);

            _uow.DepartmentRepository.Remove(department);
            _uow.Commit();

            return Ok(department);
        }
    }
}