using System.ComponentModel.DataAnnotations;

namespace TihomirsBakery.Models.Accounts
{
    public class ChangeUsernameRequest
    {
        [Required]
        public string? NewUsername { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
