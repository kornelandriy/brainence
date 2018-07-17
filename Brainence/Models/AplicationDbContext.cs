using Microsoft.EntityFrameworkCore;

namespace Brainence.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<SentenceRecordModel> SentenceRecords { get; set; }
    }
}