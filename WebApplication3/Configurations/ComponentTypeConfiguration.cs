using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Entities;

namespace WebApplication3.Configurations;

public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
{
    public void Configure(EntityTypeBuilder<ComponentType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Abbreviation).HasMaxLength(30);
        builder.Property(x => x.Name).HasMaxLength(150);
        
        builder.ToTable("ComponentTypes");

        builder.HasData(new List<ComponentType>()
        {
            new ComponentType() { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentType() { Id = 2, Abbreviation =  "AE", Name = "Aerial"},
            new ComponentType() { Id = 3, Abbreviation = "GPU", Name = "Graphics Processing Unit" }
        });
    }
}