using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacationOasis.Domain.Models;

namespace VacationOasis.Core.DatabaseContext
{
    public class VacationOasisDbContext : DbContext
    {
        public VacationOasisDbContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
    }
}
