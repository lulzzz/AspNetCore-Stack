using System.ComponentModel.DataAnnotations;

namespace AspNetCore_Stack.Controllers.Attributes
{
    public class PasswordLength : MinLengthAttribute
    {
        public PasswordLength() : base(Constants.MinimumPasswordLength)
        {
        }
    }
}