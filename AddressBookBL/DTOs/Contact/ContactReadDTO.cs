using AddressBookBL.DTOs.Department;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookBL.DTOs.Contact
{
    public class ContactReadDTO
    {
        public Guid ContactId { get; set; }

        public string Username { get; init; }

        public string Email { get; init; }

        public string Phone { get; set; }

        public DateTime DateOfBirth { get; init; }

        public string Address { get; init; }
        public string Image { get; init; }

        public String Age { get; set; }

        public ChildDepartmentReadDTO Department { get; init; }

        public ChildJobTitleReadDTO JobTitle { get; init; }
    }
}
