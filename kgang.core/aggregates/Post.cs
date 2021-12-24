using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kgang.core.aggregates
{
    public  class Post
    {
        public Post()
        {
            Comments = new List<Post>();
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Post> Comments { get; set; }
        public string UserName { get; set; }
        public string Picture { get; set; }

    }
}
