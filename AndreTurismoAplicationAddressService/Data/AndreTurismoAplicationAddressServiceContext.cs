using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreTurismoAplicationAddressService.Data
{
    public class AndreTurismoAplicationAddressServiceContext : DbContext
    {
        public AndreTurismoAplicationAddressServiceContext (DbContextOptions<AndreTurismoAplicationAddressServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Models.AddressModel> AddressModel { get; set; } = default!;
    }
}
