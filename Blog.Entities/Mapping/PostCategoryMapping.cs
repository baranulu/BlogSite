namespace Blog.Entities.Mapping
{
    using Blog.Entities.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostCategoryMapping : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.HasKey(map => new { map.PostId, map.CategoryId });

            builder.HasOne(map => map.Post)
                .WithMany(map => map.PostCategories)
                .HasForeignKey(map => map.PostId);

            builder.HasOne(map => map.Category)
                .WithMany(map => map.CategoryPosts)
                .HasForeignKey(map => map.CategoryId);
        }
    }
}


