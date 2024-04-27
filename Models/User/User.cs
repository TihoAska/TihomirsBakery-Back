using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TihomirsBakery.Models.User
{
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;

        public void SoftDelete()
        {
            IsDeleted = true;
            IsActive = false;
        }
    }
}
