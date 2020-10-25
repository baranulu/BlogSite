using System;
using Blog.Entities.Models;

namespace Blog.Business.Repositories
{
    public interface IPostRepository : ICoreRepository<Post>
    {

        public void Add(Post entity, Guid[] categories);

    }
}
