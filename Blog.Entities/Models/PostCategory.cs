using System;

namespace Blog.Entities.Models
{
    public class PostCategory
    {
        public Guid CategoryId { get; set; }
        public Guid PostId { get; set; }

        public Category Category { get; set; }
        public Post Post { get; set; }
    }
}
 