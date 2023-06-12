using Guestline.Battleships.Game.Services.Base;
using Guestline.Battleships.Game.Services;
using Guestline.Battleships.Web.Services;
using Microsoft.Extensions.FileProviders;
using Guestline.Battleships.Web.Endpoints;
using Guestline.Battleships.Web.Hubs;
using Guestline.Battleships.Web.Services.Base;
using Guestline.Battleships.Web.Commands.Handlers.Base;
using Guestline.Battleships.Web.Commands.Handlers;
using Guestline.Battleships.Domain.Services.Base;
using Guestline.Battleships.Domain.Services;

namespace Guestline.Battleships.Web
{
    internal static class Extensions
    {
        public static void RegisterDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IBoardService, BoardService>();
            builder.Services.AddTransient<IBoardPrinter, BoardPrinter>();
            builder.Services.AddTransient<IGameLoop, GameLoop>();
            builder.Services.AddTransient<IGameFactory, GameFactory>();
            builder.Services.AddTransient<IRandomService, RandomService>();
            builder.Services.AddTransient<IBoardSerializer, BoardSerializer>();
            builder.Services.AddTransient<IHitCommandHandler, HitCommandHandler>();
            builder.Services.AddTransient<INewGameCommandHandler, NewGameCommandHandler>();
            builder.Services.AddTransient<ISurrenderCommandHandler, SurrenderCommandHandler>();
            builder.Services.AddSingleton<IGameCache, GameCache>();
            builder.Services.AddSingleton<IInteractionService, AwaitingInteractionService>();
            builder.Services.AddSingleton<ISemaphoreService, SemaphoreService>();
        }

        public static void RegisterReact(this WebApplication app)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "web", "build")),
                RequestPath = ""
            });
            app.UseDefaultFiles();

            app.MapFallback(_ =>
            {
                _.Response.ContentType = "text/html";
                return _.Response.SendFileAsync(Path.Combine(Directory.GetCurrentDirectory(), "web", "build", "index.html"));
            });
        }

        public static void RegisterEndpoints(this WebApplication app)
        {
            var battleshipsApi = app.MapGroup("api/battleships/game");
            battleshipsApi.MapPost("/hit/{coordinates}", Hit.Do);
            battleshipsApi.MapPost("/new", NewGame.Do);
            battleshipsApi.MapPost("/surrender", Surrender.Do);
        }

        public static void RegisterHubs(this WebApplication app)
        {
            app.MapHub<BoardHub>("/api/battleships/hubs/board");
            app.MapHub<MessageHub>("/api/battleships/hubs/message");
        }
    }
}
