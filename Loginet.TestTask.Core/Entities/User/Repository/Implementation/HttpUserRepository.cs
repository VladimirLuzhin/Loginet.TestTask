using System.Collections.Generic;
using System.Threading.Tasks;
using Loginet.TestTask.Core.HttpClients;

namespace Loginet.TestTask.Core.Entities.User.Repository.Implementation
{
    /// <summary>
    /// Реализация репозитория с использованием Http
    /// </summary>
    public class HttpUserRepository : IUserRepository
    {
        private readonly JsonPlaceholderHttpClient _httpClient;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="httpClient">Инстанс типизированного клиента</param>
        public HttpUserRepository(JsonPlaceholderHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <inheritdoc />
        public Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            return _httpClient.GetObjectByUrl<IEnumerable<UserEntity>>("/users");
        }

        /// <inheritdoc />
        public Task<UserEntity> GetUserByIdAsync(int userId)
        {
            return _httpClient.GetObjectByUrl<UserEntity>($"/users/{userId}");
        }
    }
}