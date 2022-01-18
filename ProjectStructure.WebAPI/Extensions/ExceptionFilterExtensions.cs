using System;
using System.Net;
using ProjectStructure.BLL.Exceptions;

namespace ProjectStructure.WebAPI.Extensions
{
    public static class ExceptionFilterExtensions
    {
        public static HttpStatusCode ParseException(this Exception exception)
        {
            return exception switch
            {
                NotFoundException _ => HttpStatusCode.NotFound,
                ArgumentException _ => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };
        }
    }
}