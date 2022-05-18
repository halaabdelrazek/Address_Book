using AddressBookBL.DTOs.JobTitle;
using AddressBookBL.JobTitleBL;
using DataAL.DatabaseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Address_Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTitleController : ControllerBase
    {
        private readonly IJobTitleBL jobTitleBL;

        public JobTitleController(IJobTitleBL jobTitleBL)
        {
            this.jobTitleBL = jobTitleBL;
        }

        // GET: api/JobTitles
        [HttpGet]
        public ActionResult<IEnumerable<JobTitleReadDTO>> GetJobTitle()
        {

            return jobTitleBL.GetJobTitles();

        }

        // GET: api/JobTitle/id
        [HttpGet("{id}")]
        public ActionResult<JobTitleReadDTO> GetJobTitle(Guid id)
        {

            return jobTitleBL.GetById(id);
        }

        // PUT: api/JobTitle/id
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutJobTitle(Guid id, JobTitleWriteDTO jobTitle)
        {
            if (jobTitleBL.PutJobTitle(id, jobTitle) == -1)
            {
                return BadRequest();
            }


            if (jobTitleBL.PutJobTitle(id, jobTitle) == 0)
            {
                return NotFound();
            }


            return NoContent();
        }

        // POST: api/JobTitle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<JobTitle> PostJobTitle(JobTitleWriteDTO jobTitle)
        {
            jobTitleBL.Post(jobTitle);

            return Ok();
        }

        // DELETE: api/JobTitle/5
        [HttpDelete("{id}")]
        public IActionResult DeleteJobTitle(Guid id)
        {

            if (jobTitleBL.DeleteJobTitle(id) == 0)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
