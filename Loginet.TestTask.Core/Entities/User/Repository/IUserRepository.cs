using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loginet.TestTask.Core.Entities.User.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAllUsersAsync();

        Task<UserEntity> GetUserByIdAsync(int userId);
    }
}