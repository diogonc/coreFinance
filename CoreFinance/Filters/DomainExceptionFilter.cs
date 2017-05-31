using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Domain.Helpers.Validation;

namespace Domus.ControleDeSaldo.WebApi.Filtros
{
    public class DomainExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() != typeof (DomainException))
                return;

            var errorMessage = context.Exception.Message.Replace("\r\n", ",");
            errorMessage = errorMessage.Substring(0, errorMessage.Length - 1);
        }
    }
}