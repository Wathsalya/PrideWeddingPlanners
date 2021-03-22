using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegisterAPI.Models
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options)
        {

        }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<SaloonVendor> Saloons { get; set; }
        public DbSet<HotelVendor> Hotels { get; set; }
        public DbSet<PhotographyVendor> Photographers { get; set; }
        public DbSet<DecorationVendor> Decorators { get; set; }
        public DbSet<JwelVendor> Jwellers { get; set; }
        public DbSet<EntertainmentVendor> Entertainers { get; set; }

        public DbSet<ClientRegistration> Clients { get; set; }

        public DbSet<VendorRegistration> Vendors { get; set; }
        public DbSet<Payment> Payments { get; set; }
       




    }
}
