using Newtonsoft.Json;

namespace Loginet.TestTask.Core.Entities.User
{
    /// <summary>
    /// Компания пользователя
    /// </summary>
    public class UserCompany
    {
        /// <summary>
        /// Название компании
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Слоган, девиз компании 
        /// </summary>
        [JsonProperty("catchPhrase")]
        public string CatchPhrase { get; set; }
        
        /// <summary>
        /// Род деятельности компании
        /// </summary>
        [JsonProperty("bs")]
        public string Bs { get; set; }
    }
}