using LanguageDailyTraining.CrossCutting.Exceptions;
using LanguageDailyTraining.Domain.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Service.Middleware
{
    public class ExceptionMiddleware
    {
        public readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await this.next(httpContext);
            }
            catch (Exception ex)
            {
                await this.HandleExceptionAsync(httpContext, ex);
            }
        }

        private static ApplicationErrorCollection CreateObjectResult(Exception ex, string message)
        {
            return new ApplicationErrorCollection(
                    new ApplicationError
                    {
                        Exception = ex,
                        Message = message,
                    });
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ApplicationErrorCollection result;

            context.Response.ContentType = "application/json";
            context.Response.Headers.Add("Strict-Transport-Security", $"max-age={TimeSpan.FromDays(60)}");

            if(ex is ArgumentException || ex is DomainException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                result = CreateObjectResult(
                    ex,
                    ex.Message);
            }
            else if (ex is NotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;

                result = CreateObjectResult(
                    ex,
                    ex.Message);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                result = CreateObjectResult(
                    ex,
                    "unrecognized error");
            }

            return context.Response.WriteAsync(JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),
                },
                Formatting = Formatting.Indented,
            }));
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }

    public class ApplicationErrorCollection
    {
        public List<ApplicationError> Errors { get; set; }

        public ApplicationErrorCollection(params ApplicationError[] errors)
        {
            Errors = errors.ToList();
        }
    }

    public class ApplicationError
    {
        public string Message { get; set; }

        public Exception Exception { get; set; }
    }
}
