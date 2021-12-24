using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace kgang.infrastructure.data.repositories
{
    public class PostRepository
    {
        private readonly kgangContext context = new kgangContext();
        public int Post(string content, string name, int? parentId = null)
        {
            var post = new Post
            {
                Content = content,
                DateCreated = DateTime.Now,
                User = context.Users.Single(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase)),
                ParentId = parentId,
            };
            context.Posts.Add(post);
            context.SaveChanges();
            return post.Id;
        }
        public List<Post> GetPosts()
        {
            return context.Posts.Where(p => p.ParentId == null).Include(b => b.Comments).Include(a => a.User).OrderByDescending(a => a.Id).ToList();

        }
    }
}
