
namespace Task.InfraData.EntitiesConfiguration
{
    public class TaskConfiguration : IEntityTypeConfiguration<DomainTask>
    {
        public void Configure(EntityTypeBuilder<DomainTask> builder)
        {
            builder.HasKey(t => t.DomainTask_id);

            builder.Property(p => p.Description).HasMaxLength(900).IsRequired();

            builder.Property(p => p.OpenIn).IsRequired();

            builder.Property(p => p.Forecast).IsRequired();
        }
    }
}
