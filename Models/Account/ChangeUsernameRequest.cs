using System.ComponentModel.DataAnnotations;

namespace TihomirsBakery.Models.Account
{
    public class ChangeUsernameRequest
    {
        [Required]
        public string? NewUsername { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
