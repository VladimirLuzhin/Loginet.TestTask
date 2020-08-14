using System.Collections.Generic;
using System.Threading.Tasks;
using Loginet.TestTask.Core.HttpClients;

namespace Loginet.TestTask.Core.Entities.Album.Repository.Implementation
{
    /// <summary>
    /// Реализация репозитория с использованием Http
    /// </summary>
    public class HttpAlbumRepository : IAlbumRepository
    {
        private readonly JsonPlaceholderHttpClient _httpClient;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="httpClient">Инстанс типизированного клиента</param>
        public HttpAlbumRepository(JsonPlaceholderHttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        /// <summary>
        /// Получение списка всех альбомов
        /// </summary>
        public Task<IEnumerable<AlbumEntity>> GetAllAlbumsAsync()
        {
            return _httpClient.GetObjectByUrl<IEnumerable<AlbumEntity>>("/albums");
        }

        /// <summary>
        /// Получение альбомов пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        public Task<IEnumerable<AlbumEntity>> GetAlbumsByUserId(int userId)
        {
            return _httpClient.GetObjectByUrl<IEnumerable<AlbumEntity>>($"/albums?userId={userId}");
        }

        /// <summary>
        /// Получение альбома по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор альбома</param>
        public Task<AlbumEntity> GetAlbumByIdAsync(int id)
        {
            return _httpClient.GetObjectByUrl<AlbumEntity>($"/albums/{id}");
        }
    }
}