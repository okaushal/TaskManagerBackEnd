using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace TaskManager.Filters
{
    public class CustomFilter : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is ExceptionRepo)
            {
                var result = actionExecutedContext.Exception.Message;

                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(result),
                    ReasonPhrase = result
                };

                actionExecutedContext.Response = response;
            }
            //HttpStatusCode status = HttpStatusCode.InternalServerError;
            //var msg = string.Empty;
            //var exceptType = actionExecutedContext.Exception.GetType();
            //if (exceptType == typeof(KeyNotFoundException))
            //{
            //    msg = "This does not work.";
            //    status = HttpStatusCode.NotFound;
            //}
            //actionExecutedContext.Response = new HttpResponseMessage()
            //{
            //    Content = new StringContent(msg, System.Text.Encoding.UTF8, "text/plain"),
            //    StatusCode = status
            //};
            //base.OnException(actionExecutedContext);
        }
    }
}