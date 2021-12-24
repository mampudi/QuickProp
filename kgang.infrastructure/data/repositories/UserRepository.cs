using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace kgang.infrastructure.data.repositories
{
    public  class UserRepository
    {
        private readonly kgangContext context = new kgangContext();
        public bool RegisterUser(string name, string picture)
        {
            var user = new User
            {
                Name = name,
                Picture = "data:image/png;base64," + picture
            };
            
            context.Users.Add(user);
            context.SaveChanges();
            return true;
        }

        public bool UserExists(string name)
        {
            return context.Users.Where(a => a.Name.Equals(name)).Any();
            
        }

        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }
    }
}
