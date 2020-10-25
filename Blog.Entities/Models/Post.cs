using Blog.Entities.Core;
using System;
using System.Collections.Generic;

namespace Blog.Entities.Models
{
    public class Post : CoreEntity
    {

        public Post()
        {
            this.PostCategories = new HashSet<PostCategory>();
            this.PostImages = new HashSet<PostImage>();
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }

        public ICollection<PostImage> PostImages { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; }
    }
}