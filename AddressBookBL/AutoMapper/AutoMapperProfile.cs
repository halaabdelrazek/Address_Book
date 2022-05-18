using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AddressBookBL.DTOs.Department;
using DataAL.DatabaseModels;

namespace AddressBookBL.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, DepartmentReadDTO >();
            CreateMap<DepartmentWriteDTO, Department>();

            //CreateMap<Patient, PatientReadDTO>();
            //CreateMap<Issue, ChildIssueReadDTO>();

            //CreateMap<PatientWriteDTO, Patient>();
        }
    }
}
