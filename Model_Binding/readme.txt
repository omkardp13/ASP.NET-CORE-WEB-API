Data Binding --->
1.process of mapping HTTP request data to action method parameters.
2.ASP.NET core provides several mechanism to achieve this,enabling developrs to easy hndle input data from clients and map it to strongly typed objects.

1.Model Binding:
Model binding is a process where incoming request data is bound to controller action parameters or to the properties of a model object. 
ASP.NET Core supports binding data from various sources, including route data, query strings, form fields, and request bodies.
-------------------------------------------------------------------------------------------------------------------------------------------------------------------

1. Model Binding
Model binding is a process where incoming request data is bound to controller action parameters or to the properties of a model object. 
ASP.NET Core supports binding data from various sources, including route data, query strings, form fields, and request bodies.

Example

public class ProductController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        // 'id' parameter is bound from the route data
        var product = GetProductById(id);
        return Ok(product);
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] Product model)
    {
        // 'model' parameter is bound from the request body
        if (ModelState.IsValid)
        {
            SaveProduct(model);
            return CreatedAtAction(nameof(GetProduct), new { id = model.Id }, model);
        }
        return BadRequest(ModelState);
    }
}

-------------------------------------------------------------------------------------------------------------------------------------------------------------------

2. Attribute Routing and Binding Sources
ASP.NET Core allows you to specify the source of the data using attributes like [FromRoute], [FromQuery], [FromBody], and [FromForm].

Examples

FromRoute: Binds data from the route.

[HttpGet("{id}")]
public IActionResult GetProduct([FromRoute] int id) { ... }
-----------------------------------------------------------------------------------------------------------------------------------------------------------------
FromQuery: Binds data from the query string.

[HttpGet]
public IActionResult GetProductByName([FromQuery] string name) { ... }

-----------------------------------------------------------------------------------------------------------------------------------------------------------------
FromBody: Binds data from the request body.

[HttpPost]
public IActionResult CreateProduct([FromBody] Product model) { ... }
-----------------------------------------------------------------------------------------------------------------------------------------------------------------
FromForm: Binds data from form fields.
[HttpPost]
public IActionResult UploadProduct([FromForm] IFormFile file) { ... }

-------------------------------------------------------------------------------------------------------------------------------------------------------------------
3. Complex Types and Nested Properties
ASP.NET Core can bind complex types and their nested properties from the request data.

Example

public class Order
{
    public int Id { get; set; }
    public Customer Customer { get; set; }
}

public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
}

[HttpPost]
public IActionResult CreateOrder([FromBody] Order order)
{
    if (ModelState.IsValid)
    {
        SaveOrder(order);
        return Ok(order);
    }
    return BadRequest(ModelState);
}

-------------------------------------------------------------------------------------------------------------------------------------------------------------------

4. Custom Model Binding : You can create custom model binders if the default binding logic does not meet your needs.

Example

public class CustomDateModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        if (DateTime.TryParse(valueProviderResult.FirstValue, out var date))
        {
            bindingContext.Result = ModelBindingResult.Success(date);
        }
        else
        {
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Invalid date format");
        }

        return Task.CompletedTask;
    }
}

public class CustomDateModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType == typeof(DateTime))
        {
            return new CustomDateModelBinder();
        }
        return null;
    }
}
To register the custom model binder:

csharp
Copy code
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers(options =>
    {
        options.ModelBinderProviders.Insert(0, new CustomDateModelBinderProvider());
    });
}

-------------------------------------------------------------------------------------------------------------------------------------------------------------------

5. Validation :ASP.NET Core supports validation through data annotations and custom validation logic. 
               The ModelState object is used to check the validation state 
               of the model.

Example

public class Product
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Range(1, 100)]
    public decimal Price { get; set; }
}

[HttpPost]
public IActionResult CreateProduct([FromBody] Product model)
{
    if (ModelState.IsValid)
    {
        SaveProduct(model);
        return CreatedAtAction(nameof(GetProduct), new { id = model.Id }, model);
    }
    return BadRequest(ModelState);
}
These are the key aspects of data binding in ASP.NET Core Web API. They provide a powerful and flexible way to handle input data, ensuring that your API endpoints can accept and process data from various sources efficiently.
