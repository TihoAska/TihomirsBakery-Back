using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TihomirsBakery.Models.User
{
    public class UserUpdateRequest
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [MinLength(6, ErrorMessage = "Password needs to have a minimum of 6 characters")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Entered passwords don't match")]
        [NotMapped]
        public string? ConfirmPassword { get; set; }
    }
}
