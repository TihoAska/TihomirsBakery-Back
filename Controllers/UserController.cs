using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Threading;
using TihomirsBakery.Models.Meals;
using TihomirsBakery.Models.Users;
using TihomirsBakery.Services.IServices;

namespace TihomirsBakery.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _userService.GetAll(cancellationToken);
                return Ok(result);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetById(CancellationToken cancellationToken, int id)
        {
            try
            {
                var result = await _userService.GetById(cancellationToken, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetByFirstName(CancellationToken cancellationToken, string firstName)
        {
            try
            {
                var result = await _userService.GetByFirstName(cancellationToken, firstName);
                return Ok(result);
            }
            catch(Exception ex) 
            { 
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetByLastName(CancellationToken cancellationToken, string lastName)
        {
            try
            {
                var result = await _userService.GetByLastName(cancellationToken, lastName);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetByEmail(CancellationToken cancellationToken, string email)
        {
            try
            {
                var result = await _userService.GetByEmail(cancellationToken, email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetByUserName(CancellationToken cancellationToken, string userName)
        {
            try
            {
                var result = await _userService.GetByUserName(cancellationToken, userName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetByPhoneNumber(CancellationToken cancellationToken, string phoneNumber)
        {
            try
            {
                var result = await _userService.GetByPhoneNumber(cancellationToken, phoneNumber);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(CancellationToken cancellationToken, UserUpdateRequest userToUpdate)
        {
            try
            {
                var result = await _userService.Update(cancellationToken, userToUpdate);
                return Ok(result);
            } 
            catch (Exception ex) 
            { 
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(CancellationToken cancellationToken, int id)
        {
            try
            {
                var result = await _userService.Delete(cancellationToken, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
