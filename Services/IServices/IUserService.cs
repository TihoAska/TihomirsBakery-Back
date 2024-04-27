using Microsoft.AspNetCore.Identity;
using TihomirsBakery.Models.User;

namespace TihomirsBakery.Services.IServices
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken);
        public Task<User> GetById(CancellationToken cancellationToken, int id);
        public Task<IEnumerable<User>> GetByFirstName(CancellationToken cancellationToken, string firstName);
        public Task<IEnumerable<User>> GetByLastName(CancellationToken cancellationToken, string lastName);
        public Task<User> GetByEmail(CancellationToken cancellationToken, string email);
        public Task<User> GetByUserName(CancellationToken cancellationToken, string userName);
        public Task<User> GetByPhoneNumber(CancellationToken cancellationToken, string phoneNumber);
        public Task<IdentityResult> Delete (CancellationToken cancellationToken, int id);
        public Task<IdentityResult> Update(CancellationToken cancellationToken, UserUpdateRequest userToUpdate);
    }
}
