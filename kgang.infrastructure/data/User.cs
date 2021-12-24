using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kgang.infrastructure.data
{
    public class User
    {
        [Key, Index]
        public int Id { get; set; }
        [Index(IsUnique = true),MaxLength(255)]
        public string Name { get; set; }
        public string Picture { get; set; }
    }
}