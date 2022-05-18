using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AddressBookBL.DTOs.Department;
using DataAL.DatabaseModels;
using AddressBookBL.DTOs.JobTitle;

namespace AddressBookBL.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, DepartmentReadDTO >();
            CreateMap<DepartmentWriteDTO, Department>();

            CreateMap<JobTitle, JobTitleReadDTO>();
            CreateMap<JobTitleWriteDTO, JobTitle>();

         
        }
    }
}
