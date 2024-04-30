using TihomirsBakery.Models.Users;

namespace TihomirsBakery.Repository.IRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetById(CancellationToken cancellationToken, int id);
        public Task<User> GetByUserNameAsync(CancellationToken cancellationToken, string userName);
        public Task<IEnumerable<User>> GetByFirstNameAsync(CancellationToken cancellationToken, string firstName);
        public Task<IEnumerable<User>> GetByLastNameAsync(CancellationToken cancellationToken, string lastName);
        public Task<User> GetByEmailAsync(CancellationToken cancellationToken, string email);
        public Task<User> GetByPhoneNumberAsync(CancellationToken cancellationToken, string phoneNumber);
        public Task<User> GetByRefreshToken(CancellationToken cancellationToken, string refreshToken);
    }
}
