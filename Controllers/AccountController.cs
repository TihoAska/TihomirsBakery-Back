using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TihomirsBakery.Models.Account;
using TihomirsBakery.Models.User;
using TihomirsBakery.Services.IServices;

namespace TihomirsBakery.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IUserService _userService;
        private IAccountService _accountService;

        public AccountController(
            IUserService userService, 
            IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<ActionResult> Login(CancellationToken cancellationToken, UserLoginRequest userToLogin)
        {
            try
            {
                var result = await _accountService.Login(cancellationToken, userToLogin);
                return Ok(result);
            } 
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Refresh(CancellationToken cancellationToken, RefreshRequest model)
        {
            try
            {
                var result = await _accountService.Refresh(cancellationToken, model);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(CancellationToken cancellationToken, ChangePasswordRequest model)
        {
            try
            {
                var result = await _accountService.ChangePassword(cancellationToken, model);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> ChangeUsername(CancellationToken cancellationToken, ChangeUsernameRequest model)
        {
            try
            {
                var result = await _accountService.ChangeUsername(cancellationToken, model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Register(CancellationToken cancellationToken, UserCreateRequest model)
        {
            try
            {
                var result = await _accountService.Register(cancellationToken, model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
