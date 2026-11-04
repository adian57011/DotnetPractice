using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Extension
{
    public static class Extension
    {
        public static WebApplicationBuilder RegisterSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();

            return builder;
        }

        public static WebApplication UseSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }



    }
}
