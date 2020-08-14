using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loginet.TestTask.Core.Entities.Album.Repository
{
    /// <summary>
    /// Репозиторий для работы с альбомами
    /// </summary>
    public interface IAlbumRepository
    {
        /// <summary>
        /// Получение списка всех альбомов
        /// </summary>
        Task<IEnumerable<AlbumEntity>> GetAllAlbumsAsync();

        /// <summary>
        /// Получение списка альбомов по идентификатору пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns></returns>
        Task<IEnumerable<AlbumEntity>> GetAlbumsByUserId(int userId);

        /// <summary>
        /// Получение альбома по идентификатору альбома
        /// </summary>
        /// <param name="id">Идентификатор альбома</param>
        Task<AlbumEntity> GetAlbumByIdAsync(int id);
    }
}