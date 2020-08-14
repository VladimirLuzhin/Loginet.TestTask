using System.Collections.Generic;
using System.Threading.Tasks;
using Loginet.TestTask.Core.Entities.Album.Repository;

namespace Loginet.TestTask.Core.Entities.Album.Manager
{
    /// <summary>
    /// Сущность для управления альбомами
    /// </summary>
    public class AlbumsManager
    {
        private readonly IAlbumRepository _albumRepository;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="albumRepository">Инстанс репозитория</param>
        public AlbumsManager(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        /// <summary>
        /// Получение всех альбомов
        /// </summary>
        public Task<IEnumerable<AlbumEntity>> GetAllAlbumsAsync()
        {
            return _albumRepository.GetAllAlbumsAsync();
        }

        /// <summary>
        /// Получение альбомов пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        public Task<IEnumerable<AlbumEntity>> GetAlbumsByUserId(int userId)
        {
            return _albumRepository.GetAlbumsByUserId(userId);
        }
        
        /// <summary>
        /// Получение альбома по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        public Task<AlbumEntity> GetAlbumByIdAsync(int id)
        {
            return _albumRepository.GetAlbumByIdAsync(id);
        }
    }
}