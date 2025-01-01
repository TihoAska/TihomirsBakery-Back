using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TihomirsBakery.JWTFeatures;
using TihomirsBakery.Models.Accounts;
using TihomirsBakery.Models.Users;
using TihomirsBakery.Repository;
using TihomirsBakery.Repository.IRepository;
using TihomirsBakery.Services.IServices;

namespace TihomirsBakery.Services
{
    public class AccountService : IAccountService
    {
        IHttpContextAccessor _httpContextAccessor;
        UserManager<User> _userManager;
        IUnitOfWork _unitOfWork;
        JWTHandler _jwtHandler;
        IMapper _autoMapper;

        public AccountService(
            IHttpContextAccessor httpContextAccessor, 
            UserManager<User> userManager,
            IUnitOfWork unitOfWork,
            JWTHandler jwtHandler,
            IMapper autoMapper)
        {

            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
            _autoMapper = autoMapper;
        }

        public async Task<IdentityResult> ChangePassword(CancellationToken cancellationToken, ChangePasswordRequest model)
        {
            var httpContext = _httpContextAccessor.HttpContext ?? throw new Exception("HTTP CONTEXT is null!");

            var user = await _unitOfWork.Users.GetById(cancellationToken, int.Parse(httpContext.User.FindFirstValue("Id"))) ?? throw new Exception("User was not found!");

            if (model.NewPassword != model.ConfirmNewPassword)
            {
                throw new Exception("Passwords do not match");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if(!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                throw new Exception(string.Join(",", errors));
            }

            await _unitOfWork.SaveChangesAsync();

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> ChangeUsername(CancellationToken cancellationToken, ChangeUsernameRequest model)
        {
            var httpContext = _httpContextAccessor.HttpContext ?? throw new Exception("HTTP CONTEXT is null!");

            var user = await _unitOfWork.Users.GetById(cancellationToken, int.Parse(httpContext.User.FindFirstValue("Id"))) ?? throw new Exception("User was not found!");

            if (model.NewUsername == user.UserName)
            {
                throw new Exception("NEW USERNAME can't be the same as OLD USERNAME");
            }

            user.UserName = model.NewUsername;
            user.DateModified = DateTime.Now.ToUniversalTime();

            await _unitOfWork.SaveChangesAsync();

            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAccount(string password)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponse> Login(CancellationToken cancellationToken, UserLoginRequest userToLogin)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(cancellationToken, userToLogin.Email);

            if(user == null)
            {
                return new AuthResponse { IsAuthSuccessful = false, ErrorMessage = "Entered email is not registered for this application!", Type = "Email" };
            }

            if(!await _userManager.CheckPasswordAsync(user, userToLogin.Password))
            {
                return new AuthResponse { IsAuthSuccessful = false, ErrorMessage = "Incorrect password!", Type = "Password" };
            }

            var token = _jwtHandler.GenerateJWTToken(user);

            if (!_jwtHandler.ValidateRefreshToken(user.RefreshToken))
            {
                user.RefreshToken = _jwtHandler.GenerateJWTRefreshToken();
            }

            user.LastLogin = DateTime.Now.ToUniversalTime();

            await _unitOfWork.SaveChangesAsync();

            return new AuthResponse { IsAuthSuccessful = true, AccessToken = token, RefreshToken = user.RefreshToken };
        }

        public async Task<AuthResponse> Refresh(CancellationToken cancellationToken, RefreshRequest model)
        {
            if (string.IsNullOrEmpty(model.RefreshToken))
            {
                throw new Exception("Invalid REFRESH TOKEN");
            }

            var user = await _unitOfWork.Users.GetByRefreshToken(cancellationToken, model.RefreshToken) ?? throw new Exception("User was not found!");

            var token = _jwtHandler.GenerateJWTToken(user);

            await _unitOfWork.SaveChangesAsync();

            return new AuthResponse { IsAuthSuccessful = true, AccessToken = token, RefreshToken = user.RefreshToken };
        }

        public async Task<AuthResponse> Register(CancellationToken cancellationToken, UserCreateRequest userForRegistration)
        {
            var newUser = _autoMapper.Map<User>(userForRegistration);

            var existingEmail = await _unitOfWork.Users.GetByEmailAsync(cancellationToken, newUser.Email);
            var existingUsername = await _unitOfWork.Users.GetByUserNameAsync(cancellationToken, newUser.UserName);

            if (existingEmail != null)
            {
                return new AuthResponse { IsAuthSuccessful = false, ErrorMessage = "User with entered email already exists.", Type = "Email"};
            }

            if (existingUsername != null)
            {
                return new AuthResponse { IsAuthSuccessful = false, ErrorMessage = "User with entered user name already exists.", Type = "UserName" };
            }

            var result = await _userManager.CreateAsync(newUser, userForRegistration.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                throw new Exception(string.Join(",", errors));
            }

            var token = _jwtHandler.GenerateJWTToken(newUser);

            if (string.IsNullOrEmpty(newUser.RefreshToken))
            {
                newUser.RefreshToken = _jwtHandler.GenerateJWTRefreshToken();
            }

            newUser.LastLogin = DateTime.Now.ToUniversalTime();
            newUser.DateCreated = DateTime.Now.ToUniversalTime();
            newUser.DateModified = DateTime.Now.ToUniversalTime();

            await _unitOfWork.SaveChangesAsync();

            return new AuthResponse { IsAuthSuccessful = true, AccessToken = token, RefreshToken = newUser.RefreshToken };
        }
    }
}
