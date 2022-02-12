using System;
using DevIO.Api.Extensions;
using Elmah.Io.AspNetCore;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                //adicionar as chaves do https://elmah.io/
                o.ApiKey = "{A2C6E83B-7082-4A7A-8A86-BEC580EB0B41}";
                o.LogId = new Guid("{2429F502-C954-4780-95FA-926CB494F3AC}");
            });

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}

//Install-Package Elmah.Io.AspNetCore
//Install-Package Elmah.Io.Extensions.Logging
