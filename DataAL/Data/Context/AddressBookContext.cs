using DataAL.DatabaseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAL.Data.Context
{
    public class AddressBookContext: IdentityDbContext<User>
    {
        public DbSet<Department> Departments{ get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public AddressBookContext(DbContextOptions<AddressBookContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("AddressBookUser");
            builder.Entity<IdentityUserClaim<string>>().ToTable("AddressBookUserClaims");
        }
    }
}
