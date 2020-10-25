using Blog.Business.Data;
using Blog.Business.Repositories;
using Blog.Entities.Models;
using System.Collections.Generic;

namespace Blog.Business.Services
{
    public class PostImageRepository : CoreRepository<PostImage>, IPostImageRepository
    {
        public PostImageRepository(ApplicationContext context) : base(context) { }

        public void SetDisable(IEnumerable<PostImage> images)
        {
            throw new System.NotImplementedException();
        }
    } 
}
