using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.Data.Migration;
using OrchardCore.Modules;
using Workshop.Demo.Module.Drivers;
using Workshop.Demo.Module.Handlers;
using Workshop.Demo.Module.Indexes;
using Workshop.Demo.Module.Migrations;
using YesSql.Indexes;

namespace Workshop.Demo.Module
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddContentPart<PersonPart>().UseDisplayDriver<PersonPartDisplayDriver>().AddHandler<PersonPartHandler>();
            services.AddScoped<IDataMigration, PersonMigrations>();
            services.AddSingleton<IIndexProvider, PersonPartIndexProvider>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "Workshop.Demo.Module",
                pattern: "Home/Index",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
