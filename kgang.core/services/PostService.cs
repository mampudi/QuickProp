using kgang.core.aggregates;
using kgang.infrastructure.data.repositories;
using System.Collections.Generic;

namespace kgang.core.services
{
    public class PostService
    {
        private readonly PostRepository repo = new PostRepository();

        public int Post(string content, string name)
        {
            return repo.Post(content, name);
        }

        public int Comment(string content, string name, int parentId)
        {
            return repo.Post(content, name, parentId);
        }

        public List<Post> GetPosts()
        {
            var dbPosts = repo.GetPosts();
            var posts = new List<Post>();

            foreach (var dbPost in dbPosts)
            {
                var post = new Post();
                post.Id = dbPost.Id;
                post.UserName = dbPost.User.Name;
                post.Picture = dbPost.User.Picture;
                post.Content = dbPost.Content;
                post.DateCreated = dbPost.DateCreated;

                foreach (var dbComment in dbPost.Comments)
                {
                    post.Comments.Add(new aggregates.Post {Id = dbComment.Id, Content = dbComment.Content, DateCreated = dbComment.DateCreated, UserName = dbComment.User.Name, Picture = dbComment.User.Picture });
                }
                
                
                posts.Add(post);
            }
            return posts;
        }
    }
}
