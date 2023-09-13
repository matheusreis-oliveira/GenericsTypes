using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskSystem.Models;

namespace TaskSystem.Data.Map
{
    public class TasksMap : BaseMap<Tasks>
    {
        public override void Configure(EntityTypeBuilder<Tasks> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
