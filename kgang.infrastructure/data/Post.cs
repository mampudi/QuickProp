using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace kgang.infrastructure.data
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }

        public int? ParentId { get; set; }
        public Post Parent { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }

        public virtual List<Post> Comments { get; set; }


    }
}