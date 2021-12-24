using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kgang.web.Models
{
    public class PostsModel
    {
        public PostsModel()
        {
            Users = new List<UserModel>();
            Posts = new List<PostModel>();
        }
        public List<UserModel> Users { get; set; }
        public List<PostModel> Posts { get; set; }

        public string Name { get; set; }

        public string Post { get; set; }
        public string Comment { get; set; }

        public int Id { get; set; }

        public int PostId { get; set; }

    }
    public class PostModel
    {
        public PostModel()
        {
            Comments = new List<PostModel>();
        }
        public int Id { get; set; }

        public string Content { get; set; }
        public DateTime Date { get; set; }

        public UserModel User { get; set; }

        public List<PostModel> Comments { get; set; }

        


    }
    
}