using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Entities;

namespace WebApplication3.Configurations;

public class PCConfiguration : IEntityTypeConfiguration<PC>
{
    public void Configure(EntityTypeBuilder<PC> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Weight).HasColumnType("float(5)");
        builder.Property(x => x.Warranty).HasColumnType("int");
        builder.Property(x => x.CreatedAt).HasColumnType("datetime");
        builder.Property(x => x.Stock).HasColumnType("int");

        builder.ToTable("PCs");

        builder.HasData(new List<PC>()
        {
            new PC() { Id = 1, Name = "PC1", Weight = 12.0F, Warranty = 10, CreatedAt = new DateTime(2026,5,13), Stock = 10 },
            new PC() { Id = 2, Name = "PC2", Weight = 15.0F, Warranty = 12, CreatedAt = new DateTime(2026,5,13), Stock = 20 },
            new PC() { Id = 3, Name = "PC3", Weight = 18.0F, Warranty = 15, CreatedAt = new DateTime(2026,5,13), Stock = 30 }
        });


    }
}