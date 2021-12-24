using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kgang.core.aggregates
{
    public  class User
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Picture { get; set; }
        public List<Post> Posts { get; set; }

        public User(string name, string picture)
        {
            Name = name;
            Picture = picture;
            Posts = new List<Post>();
        }
    }
}
