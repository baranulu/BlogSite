using Blog.Entities.Core;
using System.Collections.Generic;

namespace Blog.Entities.Models
{
    public class Category : CoreEntity
    {

        public Category()
        {
            this.CategoryPosts = new HashSet<PostCategory>();
        }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<PostCategory> CategoryPosts { get; set; }
    }
}
