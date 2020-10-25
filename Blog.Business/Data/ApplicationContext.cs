using Blog.Entities;
using Blog.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace Blog.Business.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region MAPPING KULLANIYORUZ
            /*
             * 
             * MAPPING KULLANIYORUZ
             * 
             * 
            // bu tablo içerisinde 2 adet key vardır.
            modelBuilder.Entity<PostCategory>()
                .HasKey(pc => new { pc.PostId, pc.CategoryId });
           
            // bir post'un birden fazla kategorisi olur
            modelBuilder.Entity<PostCategory>()
                .HasOne(pc => pc.Post)
                .WithMany(pc => pc.PostCategories)
                .HasForeignKey(pc => pc.PostId);
           
            // bir kategorinin birden fazla post'u olur
            modelBuilder.Entity<PostCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(pc => pc.CategoryPosts)
                .HasForeignKey(pc => pc.CategoryId);
            */
            #endregion

            // Uzun yoldan yapma şekli
            //modelBuilder.ApplyConfiguration(new CategoryMapping());
            //modelBuilder.ApplyConfiguration(new PostMapping());
            //modelBuilder.ApplyConfiguration(new PostImageMapping());
            //modelBuilder.ApplyConfiguration(new PostCategoryMapping());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IMapping).Assembly); 
        }
    }
}
