using System.Runtime.Serialization;

namespace Loginet.TestTask.Album.Dto
{
    /// <summary>
    /// Сущность альбома
    /// </summary>
    [DataContract]
    public class AlbumDto
    {
        /// <summary>
        /// Идентификатор альбома
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Автор альбома
        /// </summary>
        [DataMember(Name = "userId")]
        public int UserId { get; set; }
        
        /// <summary>
        /// Описание альбома
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }
    }
}