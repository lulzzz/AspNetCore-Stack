using System.ComponentModel.DataAnnotations;

namespace AspNetCore_Stack.Entities
{
    public class UserToken: BaseEntity
    {
        [MaxLength(50)]
        public string TokenValue { get; set; }
    
        public int UserId { get; set; }
        public User User { get; set; }
    }
}