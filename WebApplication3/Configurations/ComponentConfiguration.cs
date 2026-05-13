using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Entities;

namespace WebApplication3.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.HasKey(x => x.Code);
        builder.Property(x => x.Name).HasMaxLength(300);
        builder.Property(x => x.Description).HasColumnType("nvarchar(max)");


        builder.HasOne(x => x.ComponentManufacturer)
            .WithMany(x => x.Components)
            .HasForeignKey(x => x.ComponentManufacturerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.ComponentType)
            .WithMany(x => x.Components)
            .HasForeignKey(x => x.ComponentTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new List<Component>()
        {
            new Component()
            {
                Code = "I9-13900K", Name = "Intel Core i9-13900K", Description = "Flagowy procesor Intel Core 13",
                ComponentManufacturerId = 1, ComponentTypeId = 1
            },
            new Component()
            {
                Code = "RTX4080", Name = "NVIDIA GeForce RTX 4080",
                Description = "Wydajna karta graficzna oparta na architekturze Ada Lovelace.",
                ComponentManufacturerId = 2, ComponentTypeId = 2
            },
            new Component()
            {
                Code = "990PRO2TB", Name = "Samsung 990 PRO 2TB NVMe",
                Description = "Dysk SSD M.2 PCIe Gen4 o bardzo wysokiej prędkości odczytu.",
                ComponentManufacturerId = 3, ComponentTypeId = 3
            }
        });
    }
}