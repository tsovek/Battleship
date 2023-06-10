using Guestline.Battleships.Game.Commands;
using Guestline.Battleships.Game.Commands.Handlers.Base;
using Guestline.Battleships.Game.Services;
using Guestline.Battleships.Game.Services.Base;
using Guestline.Battleships.Infrastructure;
using Guestline.Battleships.Web.Services;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Logging.AddConsole();

var dependencyInjectionResolver = new DependencyInjectionResolver(builder.Services);
dependencyInjectionResolver.RegisterSingleton<IInteractionService, AwaitingInteractionService>();
dependencyInjectionResolver.RegisterSingleton<ISemaphoreService, SemaphoreService>();
var serviceProvider = dependencyInjectionResolver.RegisterCommon();

var app = builder.Build();

var battleshipsApi = app.MapGroup("/battleships");
battleshipsApi.MapGet("/", () => Results.Ok());
battleshipsApi.MapGet("/game", () => Results.Ok());
battleshipsApi.MapPost("/game/hit/{coordinates}", Hit);
battleshipsApi.MapPost("/game/new", NewGame);

app.Run();

static IResult Hit(IServiceProvider serviceProvider, string coordinates)
{
    var handler = serviceProvider.GetService<IHitCommandHandler>();
    handler.Execute(new HitCommand { Coordinates = coordinates });

    return Results.Ok();
}

static IResult NewGame(IServiceProvider serviceProvider)
{
    var handler = serviceProvider.GetService<INewGameCommandHandler>();
    handler.ExecuteAsync(new NewGameCommand());

    return Results.Redirect("/battleships/game");
}

