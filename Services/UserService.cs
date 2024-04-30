using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using System.Runtime.CompilerServices;
using System.Threading;
using TihomirsBakery.JWTFeatures;
using TihomirsBakery.Models.Users;
using TihomirsBakery.Repository.IRepository;
using TihomirsBakery.Services.IServices;

namespace TihomirsBakery.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;
        private readonly UserManager<User> _userManager;
        private readonly JWTHandler _jwtHandler;

        public UserService(
            IUnitOfWork unitOfWork, 
            IMapper autoMapper,
            UserManager<User> userManager,
            JWTHandler jwtHandler)
        {
            _unitOfWork = unitOfWork;
            _autoMapper = autoMapper;
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }

        public async Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken)
        {
            return await _unitOfWork.Users.GetAll(cancellationToken) ?? throw new Exception("No users were found!");
        }

        public async Task<User> GetByEmail(CancellationToken cancellationToken, string email)
        {
            return await _unitOfWork.Users.GetByEmailAsync(cancellationToken, email) ?? throw new Exception("User with the given EMAIL was not found!");
        }

        public async Task<IEnumerable<User>> GetByFirstName(CancellationToken cancellationToken, string firstName)
        {
            return await _unitOfWork.Users.GetByFirstNameAsync(cancellationToken, firstName) ?? throw new Exception("Users with the given FIRST NAME were not found!");
        }

        public async Task<User> GetById(CancellationToken cancellationToken, int id)
        {
            return await _unitOfWork.Users.GetById(cancellationToken, id) ?? throw new Exception("User with the given ID was not found!");
        }

        public async Task<IEnumerable<User>> GetByLastName(CancellationToken cancellationToken, string lastName)
        {
            return await _unitOfWork.Users.GetByLastNameAsync(cancellationToken, lastName) ?? throw new Exception("Users with the given LAST NAME were not found!");
        }

        public async Task<User> GetByPhoneNumber(CancellationToken cancellationToken, string phoneNumber)
        {
            return await _unitOfWork.Users.GetByPhoneNumberAsync(cancellationToken, phoneNumber) ?? throw new Exception("User with the given PHONE NUMBER was not found!");
        }

        public async Task<User> GetByUserName(CancellationToken cancellationToken, string userName)
        {
            return await _unitOfWork.Users.GetByUserNameAsync(cancellationToken, userName) ?? throw new Exception("User with the given USER NAME was not found!");
        }

        public async Task<IdentityResult> Update(CancellationToken cancellationToken, UserUpdateRequest userToUpdate)
        {
            var userFromDb = await _unitOfWork.Users.GetById(cancellationToken, userToUpdate.Id) ?? throw new Exception("User with the given ID was not found!");

            userFromDb.FirstName = userToUpdate.FirstName;
            userFromDb.LastName = userToUpdate.LastName;
            userFromDb.UserName = userToUpdate.UserName;
            userFromDb.NormalizedUserName = userToUpdate.UserName.ToUpper();
            userFromDb.Email = userToUpdate.Email;
            userFromDb.NormalizedEmail = userToUpdate.Email.ToUpper();
            userFromDb.DateModified = DateTime.Now.ToUniversalTime();

            await _unitOfWork.SaveChangesAsync();

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> Delete(CancellationToken cancellationToken, int id)
        {
            var userFromDb = await _unitOfWork.Users.GetById(cancellationToken, id) ?? throw new Exception("User with the given ID was not found!");

            _unitOfWork.Users.Remove(userFromDb);
            await _unitOfWork.SaveChangesAsync();

            return IdentityResult.Success;
        }
    }
}
