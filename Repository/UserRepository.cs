using Microsoft.EntityFrameworkCore;
using TihomirsBakery.Data;
using TihomirsBakery.Models.User;
using TihomirsBakery.Repositories;
using TihomirsBakery.Repository.IRepository;

namespace TihomirsBakery.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IDataContext context) : base(context)
        {
                
        }

        public async Task<User> GetById(CancellationToken cancellationToken, int id)
        {
            return await _query.Where(u => u.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<User> GetByEmailAsync(CancellationToken cancellationToken, string email)
        {
            return await _query.Where(u => u.Email == email).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<User>> GetByFirstNameAsync(CancellationToken cancellationToken, string firstName)
        {
            return await _query.Where(u => u.FirstName == firstName).ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<User>> GetByLastNameAsync(CancellationToken cancellationToken, string lastName)
        {
            return await _query.Where(u => u.LastName == lastName).ToListAsync(cancellationToken);
        }

        public async Task<User> GetByUserNameAsync(CancellationToken cancellationToken, string userName)
        {
            return await _query.Where(u => u.UserName == userName).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<User> GetByPhoneNumberAsync(CancellationToken cancellationToken, string phoneNumber)
        {
            return await _query.Where(u => u.PhoneNumber == phoneNumber).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<User> GetByRefreshToken(CancellationToken cancellationToken, string refreshToken)
        {
            return await _query.Where(u => u.RefreshToken == refreshToken).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
