namespace Blog.Entities.Core
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class CoreMapping<T> : IEntityTypeConfiguration<T>
        where T : CoreEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(map => map.Id);  // birincil alan tanımlaması
            builder.Property(map => map.CreatedComputerName).HasMaxLength(150).HasColumnName("CreatedComputerName").IsRequired(true);
            builder.Property(map => map.CreatedDate).HasColumnName("CreatedDate").IsRequired(true);
            builder.Property(map => map.CreatedBy).HasMaxLength(45).HasColumnName("CreatedBy").IsRequired(true);
            builder.Property(map => map.CreatedIp).HasMaxLength(20).IsRequired(true);
        }
    } 
}


// Microsoft.EntityFrameworkCore 
// Microsoft.EntityFrameworkCore.Relational
