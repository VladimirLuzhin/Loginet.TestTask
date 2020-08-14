using System.Runtime.Serialization;

namespace Loginet.TestTask.User.Dto
{
    /// <summary>
    /// Географическое расположение адреса пользователя
    /// </summary>
    [DataContract]
    public class UserAddressGeoDto
    {
        /// <summary>
        /// Широта
        /// </summary>
        [DataMember(Name = "lat")]
        public double Latitude { get; set; }
        
        /// <summary>
        /// Долгота
        /// </summary>
        [DataMember(Name = "lng")]
        public double Longitude { get; set; }
    }
}