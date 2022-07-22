using SignalRServerExample.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials()
          .SetIsOriginAllowed(origin => true)
));

var app = builder.Build();
app.UseCors();
app.MapGet("/", () => "Hello World!");
app.MapHub<MyHub>("/myhub");

app.Run();
