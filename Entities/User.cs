using System.ComponentModel.DataAnnotations;

namespace AspNetCore_Stack.Entities
{
    public class User: BaseEntity
    {
        [MaxLength(50)]
        public string Username { get; set; }
        
        [MaxLength(50)]
        public string Password { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}