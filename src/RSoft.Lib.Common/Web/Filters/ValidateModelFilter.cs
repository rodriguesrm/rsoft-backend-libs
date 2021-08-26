using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RSoft.Lib.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace RSoft.Lib.Common.Web.Filters
{

    /// <summary>
    /// Validation filter of request models
    /// </summary>
    public class ValidateModelFilter : IActionFilter
    {

        ///<inheritdoc/>
        public void OnActionExecuted(ActionExecutedContext ctx) { }

        ///<inheritdoc/>
        public void OnActionExecuting(ActionExecutingContext ctx)
        {
            if (!ctx.ModelState.IsValid)
            {

                IEnumerable<GenericNotification> messages = ctx.ModelState
                    .Where(x => x.Value.Errors.Count() > 0)
                    .ToDictionary
                    (
                        k => k.Key,
                        v => v.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    ).Select(itm => new GenericNotification(itm.Key, string.Join('|', itm.Value)))
                    .ToList();

                BadRequestObjectResult result = new BadRequestObjectResult(messages);
                ctx.Result = result;

            }
        }
    }

}
