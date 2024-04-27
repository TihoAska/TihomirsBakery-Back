using System.ComponentModel.DataAnnotations;

namespace TihomirsBakery.Models.Account
{
    public class ChangePasswordRequest
    {
        [Required]
        public string? CurrentPassword { get; set; }

        [Required]
        public string? NewPassword { get; set; }

        [Required]
        public string? ConfirmNewPassword { get; set; }
    }
}
