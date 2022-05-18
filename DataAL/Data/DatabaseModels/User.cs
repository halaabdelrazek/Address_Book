using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAL.DatabaseModels
{
    public class User:IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

    }
}
