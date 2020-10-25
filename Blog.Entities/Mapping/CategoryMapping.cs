namespace Blog.Entities.Mapping
{
    using Blog.Entities.Core;
    using Blog.Entities.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;


    public class CategoryMapping : CoreMapping<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");  // hangi tablo ile haberleşecek veya, tablo ismi ne olacak 
            builder.Property(map => map.CategoryName).HasMaxLength(150).HasColumnName("CategoryName").IsRequired(true);
            builder.Property(map => map.Description).HasMaxLength(550).HasColumnName("Description").IsRequired(false);
             
            builder.HasMany(map => map.CategoryPosts)
                .WithOne(map => map.Category)
                .HasForeignKey(map => map.CategoryId);


            base.Configure(builder);
        }
    }
}


