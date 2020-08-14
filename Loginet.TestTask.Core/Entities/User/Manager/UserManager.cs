using System.Collections.Generic;
using System.Threading.Tasks;
using Loginet.TestTask.Core.Entities.User.Repository;

namespace Loginet.TestTask.Core.Entities.User.Manager
{
    /// <summary>
    /// Сущность для управления пользователями
    /// </summary>
    public class UserManager
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="userRepository">Инстанс репозитория</param>
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        public Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            return _userRepository.GetAllUsersAsync();
        }

        /// <summary>
        /// Получение пользователя по идентификатору
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        public Task<UserEntity> GetUserByIdAsync(int userId)
        {
            return _userRepository.GetUserByIdAsync(userId);
        }
    }
}