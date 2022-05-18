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

namespace AddressBookBL.DepartmentBL
{
    public class DepartmentBL
    {
        private readonly IDepartmentRepository deptRepo;
        private readonly IMapper _mapper;
        private readonly AddressBookContext context;

        public DepartmentBL(IDepartmentRepository deptRepo,  IMapper mapper, AddressBookContext _context)
        {
            this.deptRepo = deptRepo;
            _mapper = mapper;
            context = _context;
        }

        public IEnumerable<DepartmentReadDTO> GetDepartmnets()
        {
            var deptFromDB = deptRepo.GetAll();
            return _mapper.Map<List<DepartmentReadDTO>>(deptFromDB);
            
        }

        public int Post(DepartmentWriteDTO _dept)
        {
       
            var deptToAdd = _mapper.Map<Department> (_dept);
            deptToAdd.DepartmentId = Guid.NewGuid();
            context.Departments.Add(deptToAdd);
            return context.SaveChanges();
        }


        public DepartmentReadDTO GetById(Guid id)
        {
            var deptFromDB = context.Departments.FirstOrDefault(d => d.DepartmentId == id);

            return _mapper.Map<DepartmentReadDTO>(deptFromDB);
        }

        public int DeleteDepartment(Guid id)
        {
            deptRepo.Delete(id);
            if (!deptRepo.SaveChanges())
            {
                //Department not found
                return 0;
            }
            //department is deleted
            return 1;
        }

        public int PutDepartment(Guid id, DepartmentWriteDTO _dept)
        {
            if (id != _dept.DepartmentId)
            {
                // retun -1 to ids not equal
                return -1;
            }

            var deptToEdit = deptRepo.GetById(id);
            if (deptToEdit is null)
            {
                // retun 0 to dept not found

                return 0;
            }


            _mapper.Map(_dept, deptToEdit);


            deptRepo.Update(deptToEdit);
            deptRepo.SaveChanges();

            // retun 1 to update dept done

            return 1;
        }


    }
}
