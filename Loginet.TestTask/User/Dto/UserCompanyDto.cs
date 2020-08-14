using System.Runtime.Serialization;

namespace Loginet.TestTask.User.Dto
{
    /// <summary>
    /// Компания пользователя
    /// </summary>
    [DataContract]
    public class UserCompanyDto
    {
        /// <summary>
        /// Название компании
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Слоган, девиз компании 
        /// </summary>
        [DataMember(Name = "catchPhrase")]
        public string CatchPhrase { get; set; }
        
        /// <summary>
        /// Род деятельности компании
        /// </summary>
        [DataMember(Name = "bs")]
        public string Bs { get; set; }
    }
}