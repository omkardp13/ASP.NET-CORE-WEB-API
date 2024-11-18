                                                                                        Filters

Filters are attributes that can be applied to controllers and action methods to modify the behaviour of the request processing pipeline. 
Filters are used to implement as logging,authorization,validation,exception handling,caching & more.
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

1. Authorization Filters
Explanation: Authorization filters run first and determine whether the user is authorized to make the request. They handle authentication and authorization.

Example:

[Authorize]
public class SecureController : ControllerBase
{
    [HttpGet("secure")]
    public IActionResult SecureEndpoint()
    {
        return Ok("This is a secure endpoint.");
    }
}
In this example, the [Authorize] attribute ensures that only authenticated users can access the SecureEndpoint action.

-------------------------------------------------------------------------------------------------------------------------------------------------------------------

2. Resource Filters
Explanation: Resource filters run after authorization but before model binding and action execution. They can be used for tasks like caching or other pre-processing.

Example:

public class ResourceFilterExample : IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        // Code to execute before the action
        // Example: Check cache
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        // Code to execute after the action
        // Example: Store result in cache
    }
}

[ApiController]
[ServiceFilter(typeof(ResourceFilterExample))]
public class ResourceController : ControllerBase
{
    [HttpGet("resource")]
    public IActionResult GetResource()
    {
        return Ok("This is a resource endpoint.");
    }
}
Here, the ResourceFilterExample runs before and after the GetResource action, allowing for caching logic.
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

3. Action Filters

Explanation: Action filters run before and after the action method execution. They are useful for logging, validation, and other cross-cutting concerns.

Example:

public class ActionFilterExample : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Code to execute before the action
        // Example: Logging
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Code to execute after the action
        // Example: Logging
    }
}

[ApiController]
[ServiceFilter(typeof(ActionFilterExample))]
public class ActionController : ControllerBase
{
    [HttpGet("action")]
    public IActionResult GetAction()
    {
        return Ok("This is an action endpoint.");
    }
}
In this example, ActionFilterExample runs before and after the GetAction method, allowing for logging logic.
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

4. Exception Filters
Explanation: Exception filters run if there are any unhandled exceptions thrown during the execution of the pipeline. They are used for global error handling.

Example:

public class ExceptionFilterExample : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        // Handle the exception
        context.Result = new ContentResult
        {
            Content = "An error occurred.",
            StatusCode = 500
        };
    }
}

[ApiController]
[ServiceFilter(typeof(ExceptionFilterExample))]
public class ExceptionController : ControllerBase
{
    [HttpGet("exception")]
    public IActionResult GetException()
    {
        throw new Exception("This is an exception.");
    }
}
Here, ExceptionFilterExample handles any unhandled exceptions thrown by the GetException action.
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

5. Result Filters
Explanation: Result filters run before and after the execution of the action result. They can be used to modify the response.

Example:

public class ResultFilterExample : IResultFilter
{
    public void OnResultExecuting(ResultExecutingContext context)
    {
        // Code to execute before the result
        // Example: Modify response
    }

    public void OnResultExecuted(ResultExecutedContext context)
    {
        // Code to execute after the result
        // Example: Logging
    }
}

[ApiController]
[ServiceFilter(typeof(ResultFilterExample))]
public class ResultController : ControllerBase
{
    [HttpGet("result")]
    public IActionResult GetResult()
    {
        return Ok("This is a result endpoint.");
    }
}
In this example, ResultFilterExample runs before and after the GetResult action's result is executed, allowing for response modification and logging.
-------------------------------------------------------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

Summary
1.Authorization Filters: Ensure the user is authorized to make the request.
2.Resource Filters: Run after authorization but before model binding and action execution. Useful for caching and pre-processing.
3.Action Filters: Run before and after the action method execution. Useful for logging, validation, etc.
4.Exception Filters: Handle any unhandled exceptions during the execution of the pipeline.
5.Result Filters: Run before and after the execution of the action result. Useful for modifying the response.

These filters help in managing different aspects of request handling, enhancing the functionality and maintainability of your ASP.NET Core Web API.

---------------------------------------------------------------------------------------------------------------------------------------------------------
Built-in Filters
1.[Authorize]

2.[ServiceFilter]

3.Custom Filters

4.ResourceFilterExample (implements IResourceFilter)

5.ActionFilterExample (implements IActionFilter)

6.ExceptionFilterExample (implements IExceptionFilter)

7.ResultFilterExample (implements IResultFilter)

Breakdown

1.[Authorize]: This is a built-in filter used for authorization.

2.[ServiceFilter]: This is a built-in attribute that allows dependency injection of custom filters.

3.Custom Filters Implementation

4.ResourceFilterExample: This custom filter is implemented using IResourceFilter.

5.ActionFilterExample: This custom filter is implemented using IActionFilter.

6.ExceptionFilterExample: This custom filter is implemented using IExceptionFilter.

7.ResultFilterExample: This custom filter is implemented using IResultFilter.

So, there are 2 built-in filters and 4 custom filters mentioned in the above examples.
