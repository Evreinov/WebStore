using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Infrastructure.Middelware
{
    public class ErrorHandingMiddleware
    {
        private readonly RequestDelegate _Next;
        private readonly ILogger<ErrorHandingMiddleware> _Logger;

        public ErrorHandingMiddleware(RequestDelegate Next, ILogger<ErrorHandingMiddleware> Logger)
        {
            _Next = Next;
            _Logger = Logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _Next(context);
            }
            catch (Exception error)
            {
                HandleException(error, context);
                //throw new InvalidOperationException("Ошибка в обработке запроса", error);
                throw;
            }
        }

        private void HandleException(Exception error, HttpContext context)
        {
            _Logger.LogError(error, "Ошибка при обработке запроса к {0}", context.Request.Path);
        }
    }
}
