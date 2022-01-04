using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.SeedWork
{
    public class ValidationActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.SelectMany(x =>  x.Value.Errors.Select(e => e.ErrorMessage ));
                context.Result = new BadRequestObjectResult(new Response("Erro de validação", false, errors));
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}