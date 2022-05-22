using AddressBookBL.DepartmentBL;
using AddressBookBL.DTOs.Department;
using DataAL.DatabaseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Address_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentBL deptBL;

        public DepartmentController(IDepartmentBL deptBL)
        {
            this.deptBL = deptBL;
        }

        // GET: api/Departments
        [HttpGet]
        public ActionResult<IEnumerable<DepartmentReadDTO>> GetDepartments()
        {

            return deptBL.GetDepartmnets();

        }

        // GET: api/Department/id
        [HttpGet("{id}")]
        public ActionResult<DepartmentReadDTO> GetDepartment(Guid id)
        {

            return deptBL.GetById(id);
        }

        // PUT: api/Departments/id
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutDepartment(Guid id, DepartmentWriteDTO dept)
        {
            if (deptBL.PutDepartment(id, dept) == -1)
            {
                return BadRequest();
            }


            if (deptBL.PutDepartment(id, dept) == 0)
            {
                return NotFound();
            }


            return NoContent();
        }

        // POST: api/Department
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Department> PostDDepartment(DepartmentWriteDTO dept)
        {
            deptBL.Post(dept);

            return Ok();
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(Guid id)
        {

            if (deptBL.DeleteDepartment(id) == 0)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
