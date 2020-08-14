using Newtonsoft.Json;

namespace Loginet.TestTask.Core.Entities.User
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Email адрес пользователя
        /// </summary>
        [JsonProperty("email")]
        public string Email { get ; set; }
        
        /// <summary>
        /// Адрес пользователя
        /// </summary>
        [JsonProperty("address")]
        public UserAddress Address { get; set; }
        
        /// <summary>
        /// Телефон пользователя
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }
        
        /// <summary>
        /// Веб-сайт пользователя
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }
        
        /// <summary>
        /// Компания пользователя
        /// </summary>
        [JsonProperty("company")]
        public UserCompany UserCompany { get; set; }
    }
}