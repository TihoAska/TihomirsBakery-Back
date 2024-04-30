using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TihomirsBakery.Models.Accounts;
using TihomirsBakery.Models.Users;

namespace TihomirsBakery.Services.IServices
{
    public interface IAccountService
    {
        Task<AuthResponse> Login(CancellationToken cancellationToken, UserLoginRequest userToLogin);
        Task<AuthResponse> Refresh(CancellationToken cancellationToken, RefreshRequest model);
        Task<IdentityResult> ChangePassword(CancellationToken cancellationToken, ChangePasswordRequest model);
        Task<IdentityResult> ChangeUsername(CancellationToken cancellationToken, ChangeUsernameRequest model);
        Task<AuthResponse> Register(CancellationToken cancellationToken, UserCreateRequest userForRegistration);
        Task<IdentityResult> DeleteAccount(string password);
    }
}
