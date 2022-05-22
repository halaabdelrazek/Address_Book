using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AddressBookBL.DTOs.Department;
using DataAL.DatabaseModels;
using AddressBookBL.DTOs.JobTitle;
using DataAL.Data.DatabaseModels;
using AddressBookBL.DTOs.Contact;
using DataAL.Data.FilterContact;

namespace AddressBookBL.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, DepartmentReadDTO >();

            CreateMap<DepartmentReadDTO, Department>();


            CreateMap<DepartmentWriteDTO, Department>();

            CreateMap<JobTitle, JobTitleReadDTO>();
            CreateMap<JobTitleWriteDTO, JobTitle>();

            CreateMap<Contact, ContactDTO>();
            CreateMap<ContactDTO, Contact>();

            CreateMap<ContactReadDTO, Contact>();
            CreateMap<Contact, ContactReadDTO>();

            

            
            CreateMap<Contact, ChildContactDTO>();


            CreateMap<ChildDepartmentReadDTO, Department>();

            CreateMap<Department, ChildDepartmentReadDTO>();

            CreateMap<ChildJobTitleReadDTO,JobTitle>();

            CreateMap<JobTitle, ChildJobTitleReadDTO>();

            CreateMap<AllContactFilterDTO, FilteredContactDTO>();



        }
    }
}
