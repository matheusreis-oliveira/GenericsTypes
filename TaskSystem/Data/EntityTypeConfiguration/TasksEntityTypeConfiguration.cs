using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSystem.Models;

namespace TaskSystem.Data.Map
{
    public class TasksEntityTypeConfiguration : EntityTypeConfiguration<Tasks>
    {
        public override void Configure(EntityTypeBuilder<Tasks> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.UserId);

            builder.HasOne(x => x.User);
        }
    }
}
