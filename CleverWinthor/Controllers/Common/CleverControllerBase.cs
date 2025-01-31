using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Integracao.TOTVS.Winthor.Api.Controllers.Common
{
    public class CleverControllerBase : Controller
    {
        protected ActionResult CustomError(Exception ex)
        {
            string errors = ex.InnerException == null ? ex.Message : ex.InnerException.Message;
            return BadRequest(new string[] { errors });
        }

        protected ActionResult CustomError(ModelStateDictionary modelState)
        {
            if (modelState.IsValid) return Ok();

            var errors = modelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.Exception == null ? x.ErrorMessage : x.Exception.Message)
                .ToArray();

            return BadRequest(errors);
        }
    }
}