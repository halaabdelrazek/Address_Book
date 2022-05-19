using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookBL.DTOs.User
{
    public record LoginDTO
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
