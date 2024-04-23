var builder = WebApplication.CreateBuilder(args);

// Add services to the container. (Inject your services)
builder.Services.AddControllers(x => x.ReturnHttpNotAcceptable = true)
    .AddXmlDataContractSerializerFormatters();
var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

//app.Use(async (context, next) =>
//{
//  if(context.Request.Method == "POST")
//    {
//        await next();
//    }
//});

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Request handled by the next middleware");
//});

//to the next middleware
app.MapControllers();

app.Run();
