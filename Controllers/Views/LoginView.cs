using System.ComponentModel.DataAnnotations;
using AspNetCore_Stack.Controllers.Attributes;

namespace AspNetCore_Stack.Controllers.Views
{
    public class LoginView
    {
        [MinLength(3)]
        [MaxLength(10)]
        [Required]
        public string Username { get; set; }
        
        [PasswordLength]
        [Required]
        public string Password { get; set; }
    }
}