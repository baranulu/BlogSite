namespace Blog.Entities.Mapping
{
    using Blog.Entities.Core;
    using Blog.Entities.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostImageMapping : CoreMapping<PostImage>
    {
        public override void Configure(EntityTypeBuilder<PostImage> builder)
        {
            builder.ToTable("PostImages");
            builder.Property(map => map.ImageURL).HasMaxLength(150).HasColumnName("ImageURL").IsRequired(false);
            builder.Property(map => map.Base64).HasColumnType("VARCHAR(max)").HasColumnName("Base64").IsRequired(false);
            builder.Property(map => map.Active).HasColumnName("Active").IsRequired(true).HasDefaultValue(false);
            builder.Property(map => map.PostId).HasColumnName("PostId").IsRequired(true);

            builder.HasOne(map => map.Post)        // bir resmin bir post'u olur
                .WithMany(map => map.PostImages)   // bir post'un birden fazla resmi olur
                .HasForeignKey(map => map.PostId)  // foreign key tanımlaması
                .OnDelete(DeleteBehavior.Cascade); // bir post silinirse, ona ait resimler silinir.

            base.Configure(builder);
        }
    }
}


