namespace Blog.Entities.Mapping
{
    using Blog.Entities.Core;
    using Blog.Entities.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostMapping : CoreMapping<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {

            builder.ToTable("Posts");
            builder.Property(map => map.Title).HasMaxLength(250).HasColumnName("Title").IsRequired(true);
            builder.Property(map => map.Content).HasColumnType("nvarchar(max)").HasColumnName("Content").IsRequired(true);
            builder.Property(map => map.PublishDate).HasColumnName("PublishDate").HasColumnType("date").IsRequired(true);

            builder.HasMany(map => map.PostImages)    // bir post'un birden fazla, resmi olur
                .WithOne(map => map.Post)             // bir resmin bir tane post'u olur
                .HasForeignKey(map => map.PostId)     // ikincil alan tanımlaması
                .OnDelete(DeleteBehavior.Cascade);    // bir post silindiğinde, resimler silinir.


            builder.HasMany(map => map.PostCategories)
                .WithOne(map => map.Post)
                .HasForeignKey(map => map.PostId);

            base.Configure(builder);
        }
    }
}


