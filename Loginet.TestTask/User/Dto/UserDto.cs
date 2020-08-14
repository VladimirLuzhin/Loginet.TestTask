using System.Runtime.Serialization;

namespace Loginet.TestTask.User.Dto
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [DataContract]
    public class UserDto
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
        
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Email адрес пользователя
        /// </summary>
        [DataMember(Name = "email")]
        public string Email { get ; set; }
        
        /// <summary>
        /// Адрес пользователя
        /// </summary>
        [DataMember(Name = "address")]
        public UserAddressDto Address { get; set; }
        
        /// <summary>
        /// Телефон пользователя
        /// </summary>
        [DataMember(Name = "phone")]
        public string Phone { get; set; }
        
        /// <summary>
        /// Веб-сайт пользователя
        /// </summary>
        [DataMember(Name = "website")]
        public string Website { get; set; }
        
        /// <summary>
        /// Компания пользователя
        /// </summary>
        [DataMember(Name = "company")]
        public UserCompanyDto UserCompany { get; set; }
    }
}