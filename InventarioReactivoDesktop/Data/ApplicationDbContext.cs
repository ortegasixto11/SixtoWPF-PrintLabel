using InventarioReactivoDesktop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioReactivoDesktop.Data
{
    public class ApplicationDbContext : DbContext
    {
        private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-Quimica-53bc9b9d-9d6a-45d4-8429-2a2761773507;Trusted_Connection=True;MultipleActiveResultSets=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public virtual DbSet<User> RI_USERS { get; set; }
        public virtual DbSet<Container> RI_CONTAINERS { get; set; }
    }
}
