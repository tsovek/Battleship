using Guestline.Battleships.Game.Services.Base;
using Guestline.Battleships.Game.Services;
using Guestline.Battleships.Infrastructure;
using Guestline.Battleships.Web.Services;
using Microsoft.Extensions.FileProviders;
using Guestline.Battleships.Web.Endpoints;
using Guestline.Battleships.Web.Hubs;
using Guestline.Battleships.Web.Services.Base;

namespace Guestline.Battleships.Web
{
    internal static class Extensions
    {
        public static void RegisterDependencies(this WebApplicationBuilder builder)
        {
            var dependencyInjectionResolver = new DependencyInjectionResolver(builder.Services);
            dependencyInjectionResolver.RegisterSingleton<IBoardSerializer, BoardSerializer>();
            dependencyInjectionResolver.RegisterSingleton<IInteractionService, AwaitingInteractionService>();
            dependencyInjectionResolver.RegisterSingleton<ISemaphoreService, SemaphoreService>();
            dependencyInjectionResolver.RegisterCommon();
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
