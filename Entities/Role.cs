using System.ComponentModel.DataAnnotations;

namespace AspNetCore_Stack.Entities
{
    public class Role 
    {
        public int Id { get; set; }
        
        [MaxLength(50)]
        public string RoleName { get; set; }
    }
}