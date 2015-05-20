using Microsoft.Data.Entity;
using VotR.Db.Entities;

namespace VotR.Db.VotRDbContext
{
    public partial class VotRDbContext
    {
        public DbSet<Beer> Beer { get; set; }
    }
}
