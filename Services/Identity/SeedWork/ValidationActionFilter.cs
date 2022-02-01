using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Identity.SeedWork
{
    public class ValidationActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.SelectMany(x => x.Value.Errors.Select(e => e.ErrorMessage));
                context.Result = new BadRequestObjectResult(
                    Response.Fail().WithMessage("Erro de validação")
                    .WithData(errors));
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
         
        }
    }
}