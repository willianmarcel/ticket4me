using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ticket4me.Domain.Entities;

namespace Ticket4me.Infra.Data.EF.Configurations.v1;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(category => category.Id);
        builder.Property(category => category.Name).HasMaxLength(255);
        builder.Property(category => category.Description).HasMaxLength(10_000);
    }
}
