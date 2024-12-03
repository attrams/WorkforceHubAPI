using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WorkforceHubAPI.Entities.ErrorModel;

namespace WorkforceHubAPI.WebAPI.Presentation.ActionFilters;

/// <summary>
/// A custom validation filter attribute that validates action method parameters and
/// model state.
/// </summary>
public class ValidationFilterAttribute : IActionFilter
{
    public ValidationFilterAttribute() { }

    /// <summary>
    /// Called after the action method is executed.
    /// </summary>
    /// <param name="context">The context for the action executed.</param>
    public void OnActionExecuted(ActionExecutedContext context)
    {

    }

    /// <summary>
    /// Called before the action method is executed to validate the action parameters and model state.
    /// </summary>
    /// <param name="context">The context for the action being executed/</param>
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Retrieve the action and controller names for error messages.
        var action = context.RouteData.Values["action"];
        var controller = context.RouteData.Values["controller"];

        // Check if the action method has a parameter containing "Dto" in its name.
        var param = context.ActionArguments.SingleOrDefault(x => x.Value!.ToString()!.Contains("Dto")).Value;
        if (param is null)
        {
            context.Result = new BadRequestObjectResult(new ErrorDetails()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Invalid or missing Data Transfer object."
            });
            return;
        }

        // If the model state is invalid, return an Unprocessable Entity response with model state details.
        if (!context.ModelState.IsValid)
        {
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }
    }
}