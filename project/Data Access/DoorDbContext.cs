using Microsoft.EntityFrameworkCore;
using project.Models;
using System;

namespace project.Data_Access
{
    public class DoorDbContext : DbContext
    {
        public DoorDbContext(DbContextOptions<DoorDbContext> options) : base(options)
        {

        }

        public DbSet<Door> Doors { get; set; }

    }
}
