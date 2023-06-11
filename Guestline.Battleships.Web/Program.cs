using Guestline.Battleships.Web;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Logging.AddConsole();
builder.Services.AddSignalR();
builder.RegisterDependencies();
var app = builder.Build();

app.RegisterReact();
app.RegisterEndpoints();
app.RegisterHubs();

app.Run();