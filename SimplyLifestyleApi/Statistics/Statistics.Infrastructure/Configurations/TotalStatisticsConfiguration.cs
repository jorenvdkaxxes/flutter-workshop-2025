using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Statistics.Domain;

namespace Statistics.Infrastructure;

internal class TotalStatisticsConfiguration : IEntityTypeConfiguration<TotalStatistics>
{
    public void Configure(EntityTypeBuilder<TotalStatistics> builder)
    {
        builder
            .HasKey(s => s.Id);
            
        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd();
    }
}
