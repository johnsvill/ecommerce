using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WebApi.Errors;

namespace WebApi.Middleware
{
    public class ExeptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExeptionMiddleware> _logger;
        private readonly IHostEnvironment _host;

        public ExeptionMiddleware(RequestDelegate next, ILogger<ExeptionMiddleware> logger,
            IHostEnvironment host)
        {
            this._next = next;
            this._logger = logger;
            this._host = host;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this._next(context);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);

                var response = this._host.IsDevelopment()//Operación de tipo ternaria
                    ? new CodeErrorException(Convert.ToInt32(HttpStatusCode.InternalServerError),
                    e.Message, e.StackTrace.ToString())
                    : new CodeErrorException(Convert.ToInt32(HttpStatusCode.InternalServerError));

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);

                throw;
            }
        }
    }
}
