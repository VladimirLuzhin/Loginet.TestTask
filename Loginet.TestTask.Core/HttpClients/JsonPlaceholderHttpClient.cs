using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Loginet.TestTask.Core.HttpClients
{
    /// <summary>
    /// HttpClient для взаиомдействия с jsonplaceholder api
    /// </summary>
    public class JsonPlaceholderHttpClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// .ctor 
        /// </summary>
        /// <param name="httpClient">Инстанс клиента для отправки запрсов</param>
        public JsonPlaceholderHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Получение объекта по заданному URL и преобразование к заданному типу
        /// </summary>
        /// <param name="url">Адрес запроса</param>
        /// <typeparam name="T">Тип данных, к которому нужно привести полученный объект</typeparam>
        public async Task<T> GetObjectByUrl<T>(string url)
        {
            var json = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}