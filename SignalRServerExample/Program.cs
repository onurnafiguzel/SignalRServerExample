using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials()
          .SetIsOriginAllowed(origin => true)
));
builder.Services.AddTransient<MyBusiness>();
builder.Services.AddSignalR();
builder.Services.AddControllers();

var app = builder.Build();
app.UseCors();
app.MapGet("/", () => "Hello World!");
app.MapHub<MyHub>("/myhub");
app.MapControllers();

app.Run();
