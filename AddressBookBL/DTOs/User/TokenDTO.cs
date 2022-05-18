using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookBL.DTOs.User
{

    public record TokenDTO
    {
        public string Token { get; init; }
        public DateTime ExpiryDate { get; set; }
    }

}














