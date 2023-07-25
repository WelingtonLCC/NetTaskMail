
namespace Sender.InfraData.Context
{
    public class SenderApplicationDbContext : DbContext
    {
        public SenderApplicationDbContext(DbContextOptions<SenderApplicationDbContext> options) : base(options) { }

        public DbSet<SenderConfigDomain> SenderConfigDomain { get; set; }
        public DbSet<SenderMailDomain> SenderMailDomain { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(SenderApplicationDbContext).Assembly);
        }
    }
}
