using Newtonsoft.Json;

namespace Loginet.TestTask.Core.Entities.Album
{
    /// <summary>
    /// Сущность альбома
    /// </summary>
    public class AlbumEntity
    {
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Автор альбома
        /// </summary>
        [JsonProperty("userId")]
        public int UserId { get; set; }
        
        /// <summary>
        /// Описание альбома
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}