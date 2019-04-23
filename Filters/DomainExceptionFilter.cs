using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using CoreFinance.Domain.Helpers.Validation;
using System;

namespace CoreFinance.Filters
{
    public class DomainExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() != typeof(DomainException)
                && context.Exception.GetType().BaseType != typeof(DomainException))
                return;

            var errorMessage = context.Exception.Message.Replace("\r\n", ",");
            errorMessage = errorMessage.Substring(0, errorMessage.Length - 1);

            context.Result = new JsonResult(errorMessage) { StatusCode = 422 };
            context.ExceptionHandled = true;

            base.OnException(context);
        }
    }
}