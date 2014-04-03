using System.Web.Http;
using Ninject;
using RockPaperScissors.App;
using RockPaperScissors.App.Repository;
using RockPaperScissors.Contracts;
using RockPaperScissors.Web.DependencyInjection;
using RockPaperScissors.Web.Filters;

namespace RockPaperScissors.Web.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ConfigureRoutes(config);
            ConfigureDepencyResolver(config);
            config.Filters.Add(new ValidationActionFilter());
        }

        private static void ConfigureRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "GetGameTypes",
                routeTemplate: "api/{controller}/types",
                defaults: new {action = "GetGameTypes"});

            config.Routes.MapHttpRoute(
                name: "GetMoveNames",
                routeTemplate: "api/{controller}/moves",
                defaults: new { action = "GetMoveNames" });

            config.Routes.MapHttpRoute(
                name: "GetRandomMoveName",
                routeTemplate: "api/{controller}/moves/random",
                defaults: new { action = "GetRandomMoveName" });

            // Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
        }

        private static void ConfigureDepencyResolver(HttpConfiguration config)
        {
            var kernel = new StandardKernel();
            ConfigureDependencyBindings(kernel);
            config.DependencyResolver = new NinjectResolver(kernel);
        }

        private static void ConfigureDependencyBindings(StandardKernel kernel)
        {
            kernel.Bind<IGameEngine>().To<GameEngine>();
            kernel.Bind<IGameValidation>().To<GameValidation>();
            kernel.Bind<IAppRepository>().To<AppRepository>();
        }
    }
}