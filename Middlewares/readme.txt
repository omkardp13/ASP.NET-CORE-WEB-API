Middleware ---> Software components that handle ewquests and responses in asp.net core pipeline

1.Middleware is nothing but a component (class) which is executed on every request
2.middleware controlls how our application responds to http request

What are some best practices for writing custom middleware in ASP.NET Core?

Answer: Some best practices include:
Keeping middleware focused on a single responsibility.
Ensuring middleware is reusable and configurable.
Properly handling exceptions within middleware.
Avoiding blocking calls and using asynchronous patterns.
Respecting the order of middleware components for correct request processing.
