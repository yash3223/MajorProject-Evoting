using Microsoft.EntityFrameworkCore;
using SmartVotingSystem.Models;
using SmartVotingSystem.UI.Models;

namespace SmartVotingSystem.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
        }
        public DbSet<ApplicationUsers> ApplicationUser { get; set; }
        public DbSet<PartiesMaster> PartiesMasters { get; set; }

        public DbSet<VoteMaster> VoteMasters { get; set; }
    }
}
