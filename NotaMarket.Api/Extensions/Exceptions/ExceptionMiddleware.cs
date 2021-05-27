using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NotaMarket.Api.Model;
using Serilog;

namespace NotaMarket.Api.Extensions.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        static readonly ILogger Log = Serilog.Log.ForContext<ExceptionMiddleware>();
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var now = DateTime.UtcNow;
            Log.Error($"{now.ToString("HH:mm:ss")} : {ex}");
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new ResponseObjectModel<string>()
            {
                Success = false,
                Message = ex.Message,
                Response = null,
                StatusCode = httpContext.Response.StatusCode,
            }.ToString()));
        }
    }
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}


