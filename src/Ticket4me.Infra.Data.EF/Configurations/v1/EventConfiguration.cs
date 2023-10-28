using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket4me.Domain.Entities;

namespace Ticket4me.Infra.Data.EF.Configurations.v1;
public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(255);
        builder.Property(x => x.Description).HasMaxLength(10_000);
    }
}
