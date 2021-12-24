using kgang.core.aggregates;
using kgang.infrastructure.data.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kgang.core.services
{
    public class UserService
    {
        private readonly UserRepository repo = new UserRepository();

        public bool RegisterUser(string name, string picture)
        {
            return repo.RegisterUser(name, picture);
        }
        public bool UserExists(string name)
        {
            return repo.UserExists(name);
        }

        public List<User> GetUsers()
        {
            var dbUsers = repo.GetUsers();
            var users = new List<User>();

            foreach (var dbUser in dbUsers)
            {
                var user = new User(dbUser.Name, dbUser.Picture);
                user.Id = dbUser.Id;
                users.Add(user);
            }
            return users;
        }
    }
}
