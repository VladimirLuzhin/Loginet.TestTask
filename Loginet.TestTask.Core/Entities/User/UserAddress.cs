using Newtonsoft.Json;

namespace Loginet.TestTask.Core.Entities.User
{
    /// <summary>
    /// Адрес пользователя
    /// </summary>
    public class UserAddress
    {
        /// <summary>
        /// Улица
        /// </summary>
        [JsonProperty("street")]
        public string Street { get; set; }
        
        /// <summary>
        /// Номер дома
        /// </summary>
        [JsonProperty("suite")]
        public string Suite { get; set; }
        
        /// <summary>
        /// Название города
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }
        
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }
        
        /// <summary>
        /// Географическое расположение
        /// </summary>
        [JsonProperty("geo")]
        public UserAddressGeo Geo { get; set; }
    }
}