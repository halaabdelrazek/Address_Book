using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookBL.DTOs.User
{
    public record RegisterDTO
    {
        public string Username { get; init; }


        [Required(ErrorMessage = "You must provide Email")]

        [EmailAddress(ErrorMessage = "Email is wrong")]
        public string Email { get; init; }


        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+201|01|00201)[0-2,5]{1}[0-9]{8}", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }


        public DateTime DateOfBirth { get; init; }


        public string Password { get; init; }

        public string Address { get; init; }
        public string Image { get; init; }

        public String Age { get; set; }



    }
}
