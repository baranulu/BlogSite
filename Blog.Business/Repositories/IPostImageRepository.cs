using Blog.Entities.Models;
using System.Collections.Generic;

namespace Blog.Business.Repositories
{
    public interface IPostImageRepository : ICoreRepository<PostImage>
    {
        public void SetDisable(IEnumerable<PostImage> images);
    }
}
