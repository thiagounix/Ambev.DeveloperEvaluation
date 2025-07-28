using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
               .HasColumnType("uuid")
               .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(s => s.CustomerName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.SaleDate)
               .IsRequired();

        builder.HasMany(s => s.Items)
               .WithOne()
               .HasForeignKey(i => i.SaleId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(s => s.BranchName)
                .HasMaxLength(100);

        builder.Property(s => s.TotalAmount)
               .HasColumnType("decimal(18,2)");

        builder.Property(s => s.IsCancelled)
               .HasDefaultValue(false);

        builder.Property(s => s.CreatedAt)
               .IsRequired();

        builder.Property(s => s.UpdatedAt);

    }
}