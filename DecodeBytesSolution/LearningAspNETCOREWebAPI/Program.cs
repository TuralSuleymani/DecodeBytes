using LearningAspNETCOREWebAPI.Db;
using LearningAspNETCOREWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
configuration.ReadFrom.Configuration(context.Configuration));

//providers: debug,console,file,3rd party

// Add services to the container. (Inject your services)
builder.Services.AddControllers(x => x.ReturnHttpNotAcceptable = true)
    .AddNewtonsoftJson()
    .AddXmlDataContractSerializerFormatters();

builder.Services.AddTransient<NotificationService>();
builder.Services.AddTransient<TransactionService>();

builder.Services.AddDbContext<MyDbContext>(x => x.UseSqlite("Data Source=MySqliteDb.db"));
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

app.UseSerilogRequestLogging();
//to the next middleware
app.MapControllers();

app.Run();
