using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Loginet.TestTask.Middlewares
{
    /// <summary>
    /// Middleware для перехвата всех необработанных исключений
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="next">Делегат вызова следующей middleware</param>
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Обработка текущей Middlewrae
        /// </summary>
        /// <param name="context">Контекст запроса</param>
        /// <param name="logger">Логгер</param>
        public async Task Invoke(HttpContext context, ILogger<ErrorHandlingMiddleware> logger)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var errorCode = Guid.NewGuid();
                
                // в идеале тут нужно сохранить информацию о запросе (путь, параметры, тело) и стэк вызова
                logger.LogError($"Ошибка {errorCode}. Exception={ex}");
                
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                await context.Response.WriteAsync($"При выполнении операции произошла ошибка - {errorCode}. Причина={ex.Message}");
            }
        }
    }
}