using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication3.Entities;

namespace WebApplication3.Configurations;

public class PCComponentConfiguration : IEntityTypeConfiguration<PCComponent>
{
    public void Configure(EntityTypeBuilder<PCComponent> builder)
    {
        builder.HasKey(p => new { p.PCId, p.ComponentCode} );
        builder.Property(p => p.Amount).HasColumnType("int");
        
        builder.HasOne(p => p.PC)
            .WithMany(p => p.PcComponents)
            .HasForeignKey(p => p.PCId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.Component)
            .WithMany(p => p.PCComponents)
            .HasForeignKey(p => p.ComponentCode)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new List<PCComponent>()
        {
            new PCComponent() { PCId = 1, ComponentCode = "I9-13900K", Amount = 1 },
            new PCComponent() { PCId = 2, ComponentCode ="RTX4080", Amount = 1 },
            new PCComponent() { PCId = 3, ComponentCode = "990PRO2TB", Amount = 2 }
        });
    }
    
}