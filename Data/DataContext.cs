
using Microsoft.EntityFrameworkCore;
using Webapi.Models;

namespace Webapi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base (options){}

        public DbSet<Appointment> Appointments { get; set; }
    }
}
