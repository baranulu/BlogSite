using Blog.Entities.Core;
using System;

namespace Blog.Entities.Models
{
    public class PostImage : CoreEntity
    {
        public string ImageURL { get; set; }
        public string Base64 { get; set; }
        public bool Active { get; set; }

        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}



/*
   bir kategorinin birden fazla postu olabilir
   bir postun birden fazla kategorisi olabilir
   bir postun birden fazla resmi olabilir
   bir resmin bir postu olur
 
 */
