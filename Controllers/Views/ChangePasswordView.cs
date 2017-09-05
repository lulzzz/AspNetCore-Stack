using System.ComponentModel.DataAnnotations;
using AspNetCore_Stack.Controllers.Attributes;

namespace AspNetCore_Stack.Controllers.Views
{
    public class ChangePasswordView
    {
        [PasswordLength]
        [Required]
        public string Password { get; set; }
        
        [PasswordLength]
        [Required]
        public string OldPassword { get; set; }
    }
}