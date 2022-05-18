using AddressBookBL.DTOs.Department;
using AutoMapper;
using DataAL.Data.Context;
using DataAL.Data;
using AddressBookBL.DTOs.Department;
using DataAL.Repositories.DepartmentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAL.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using DataAL.Repositories.JobTitleRepository;
using AddressBookBL.DTOs.JobTitle;

namespace AddressBookBL.JobTitleBL
{
    public class JobTitleBL : IJobTitleBL
    {
        private readonly IJobTitleRepository jobTitleRepo;
        private readonly IMapper _mapper;
        private readonly AddressBookContext context;

        public JobTitleBL(IJobTitleRepository jobTitleRepo, IMapper mapper, AddressBookContext _context)
        {
            this.jobTitleRepo = jobTitleRepo;
            _mapper = mapper;
            context = _context;
        }

        public ActionResult< IEnumerable<JobTitleReadDTO>> GetJobTitles()
        {
            var jobTitleFromDB = jobTitleRepo.GetAll();
            return _mapper.Map<List<JobTitleReadDTO>>(jobTitleFromDB);

        }

        public int Post(JobTitleWriteDTO _jobTitle)
        {
            var jobTitleToAdd = _mapper.Map<JobTitle>(_jobTitle);
            jobTitleToAdd.JobTitleId = Guid.NewGuid();
            context.JobTitles.Add(jobTitleToAdd);
            return context.SaveChanges();
        }


        public ActionResult<JobTitleReadDTO> GetById(Guid id)
        {
            var jobTitleFromDB = context.JobTitles.FirstOrDefault(j => j.JobTitleId == id);

            return _mapper.Map<JobTitleReadDTO>(jobTitleFromDB);
        }

        public int DeleteJobTitle(Guid id)
        {
            jobTitleRepo.Delete(id);
            if (!jobTitleRepo.SaveChanges())
            {
                //Department not found
                return 0;
            }
            //department is deleted
            return 1;
        }

        public int PutJobTitle(Guid id, JobTitleWriteDTO _jobTitle)
        {
            if (id != _jobTitle.JobTitleId)
            {
                // retun -1 to ids not equal
                return -1;
            }

            var jobTitleToEdit = jobTitleRepo.GetById(id);
            if (jobTitleToEdit is null)
            {
                // retun 0 to dept not found

                return 0;
            }


            _mapper.Map(_jobTitle, jobTitleToEdit);


            jobTitleRepo.Update(jobTitleToEdit);
            jobTitleRepo.SaveChanges();

            // retun 1 to update dept done

            return 1;
        }

      
    }

   
}
