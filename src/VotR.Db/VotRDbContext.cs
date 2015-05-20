
using Microsoft.Data.Entity;

namespace VotR.Db.VotRDbContext
{
    public partial class VotRDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("");
        }
    }
}
