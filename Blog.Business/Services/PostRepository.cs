using System;
using Blog.Business.Data;
using Blog.Business.Repositories;
using Blog.Entities.Models;

namespace Blog.Business.Services
{
    public class PostRepository : CoreRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationContext context) : base(context) { }

        public void Add(Post entity, Guid[] categories)
        {
            foreach (Guid id in categories)
            {
                entity.PostCategories.Add(new PostCategory { Post = entity, CategoryId = id });
            }
            Add(entity);
        }
    }
}
