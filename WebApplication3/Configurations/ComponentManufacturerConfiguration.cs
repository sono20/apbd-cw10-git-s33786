using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Entities;

namespace WebApplication3.Configurations;

public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
{
    public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Abbreviation).HasMaxLength(30);
        builder.Property(x => x.FullName).HasMaxLength(300);
        builder.Property(x => x.FoundationDate).HasColumnType("date");
        
        builder.ToTable("ComponentManufacturers");

        builder.HasData(new List<ComponentManufacturer>()
        {
            new ComponentManufacturer() { Id = 1, Abbreviation = "TI", FullName = "Texas Instruments" },
            new ComponentManufacturer()
            {
                Id = 2, Abbreviation = "ST", FullName = "STMicroelectronics", FoundationDate = new DateOnly(2000, 1, 1)
            },
            new ComponentManufacturer()
            {
                Id = 3, Abbreviation = "AMD", FullName = "Advanced Micro Devices",
                FoundationDate = new DateOnly(2000, 1, 1)
            }
        });
    }
}