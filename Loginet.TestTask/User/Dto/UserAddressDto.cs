using System.Runtime.Serialization;

namespace Loginet.TestTask.User.Dto
{
    /// <summary>
    /// Адрес пользователя
    /// </summary>
    [DataContract]
    public class UserAddressDto
    {
        /// <summary>
        /// Улица
        /// </summary>
        [DataMember(Name = "street")]
        public string Street { get; set; }
        
        /// <summary>
        /// Номер дома
        /// </summary>
        [DataMember(Name = "suite")]
        public string Suite { get; set; }
        
        /// <summary>
        /// Название города
        /// </summary>
        [DataMember(Name = "city")]
        public string City { get; set; }
        
        /// <summary>
        /// Почтовый индекс
        /// </summary>
        [DataMember(Name = "zipcode")]
        public string Zipcode { get; set; }
        
        /// <summary>
        /// Географическое расположение
        /// </summary>
        [DataMember(Name = "geo")]
        public UserAddressGeoDto Geo { get; set; }
    }
}