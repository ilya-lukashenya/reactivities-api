using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext : DbContext
    {
        
        public DataContext ([NotNullAttribute] DbContextOptions opsions) : base (opsions)
        {
            
        }


        public DbSet<Activity> Activities { get; set; }
    }
}