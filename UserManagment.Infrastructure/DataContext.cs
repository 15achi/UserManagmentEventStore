using Microsoft.EntityFrameworkCore;
using Nest;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UserManagment.Domain.User;

namespace UserManagment.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //public DbSet<User> Users { get; set; }
        public DbSet<EventStore> EventStores { get; set; }
        protected override void OnModelCreating(ModelBuilder Builder)
        {
           
        }
    }
}
