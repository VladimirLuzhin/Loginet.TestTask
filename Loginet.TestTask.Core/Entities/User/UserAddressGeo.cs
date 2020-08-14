using Newtonsoft.Json;

namespace Loginet.TestTask.Core.Entities.User
{
    /// <summary>
    /// Географическое расположение адреса пользователя
    /// </summary>
    public class UserAddressGeo
    {
        /// <summary>
        /// Широта
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        
        /// <summary>
        /// Долгота
        /// </summary>
        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
}