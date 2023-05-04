using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreTurismoApp.CityService.Data
{
    public class AndreTurismoAppCityServiceContext : DbContext
    {
        public AndreTurismoAppCityServiceContext (DbContextOptions<AndreTurismoAppCityServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Models.CityModel> CityModel { get; set; } = default!;
    }
}
