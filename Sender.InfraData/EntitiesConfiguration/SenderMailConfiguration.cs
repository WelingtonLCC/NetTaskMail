
namespace Sender.InfraData.EntitiesConfiguration
{
    public class SenderMailConfiguration : IEntityTypeConfiguration<SenderMailDomain>
    {
        public void Configure(EntityTypeBuilder<SenderMailDomain> builder)
        {
            builder.HasKey(t => t.Sender_id);
            builder.Property(p => p.Sender_title).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Sender_email).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Sender_message).HasMaxLength(999).IsRequired();
        }
    }
}
