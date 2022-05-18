using AddressBookBL.DTOs.Department;
using Microsoft.AspNetCore.Mvc;

namespace AddressBookBL.DepartmentBL
{
    public interface IDepartmentBL
    {
        int DeleteDepartment(Guid id);
        ActionResult<DepartmentReadDTO> GetById(Guid id);
        ActionResult< IEnumerable<DepartmentReadDTO>> GetDepartmnets();
        int Post(DepartmentWriteDTO _dept);
        int PutDepartment(Guid id, DepartmentWriteDTO _dept);
    }
}