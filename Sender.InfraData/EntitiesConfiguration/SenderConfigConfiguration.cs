namespace Sender.InfraData.EntitiesConfiguration
{
    public class SenderConfigConfiguration : IEntityTypeConfiguration<SenderConfigDomain>
    {
        public void Configure(EntityTypeBuilder<SenderConfigDomain> builder)
        {
            builder.HasKey(t => t.Sender_id);
            builder.Property(p => p.Sender_user).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Sender_smtp).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Sender_password).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Sender_port).HasMaxLength(3).IsRequired();

            builder.HasData(
                new SenderConfigDomain(1,"welington.campos@futurasistemas.com.br", "smtp.futurasistemas.com.br", "We@172839", "587")
                );
        }
    }
}
