using AddressBookBL.DTOs.JobTitle;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookBL.JobTitleBL
{
    public interface IJobTitleBL
    {
        int DeleteJobTitle(Guid id);
        ActionResult<JobTitleReadDTO> GetById(Guid id);
        ActionResult<IEnumerable<JobTitleReadDTO>> GetJobTitles();
        int Post(JobTitleWriteDTO _jobTitle);
        int PutJobTitle(Guid id, JobTitleWriteDTO _jobTitle);
    }
}