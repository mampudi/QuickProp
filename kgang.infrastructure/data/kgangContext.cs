using System.Data.Entity;
using System.Linq;

namespace kgang.infrastructure.data
{
    public class kgangContext : DbContext
    {
        public kgangContext()
            : base("kgangContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
    }
}