using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using Shared.Model;
using System.Text;

namespace Shared.Extension
{
    public static class Extension
    {
        public static WebApplicationBuilder RegisterSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();

            return builder;
        }

        public static WebApplication UseRegisteredSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }


        public static WebApplication UseScaler(this WebApplication app)
        {
            // must register openapi support in builder services to work //
            app.MapScalarApiReference();

            return app;
        }


        public static WebApplicationBuilder RegisterJwtBasedAuthentication(this WebApplicationBuilder builder, IConfiguration config)
        {
            builder.Services
                .AddOptions<JwtSetting>()
                .BindConfiguration(JwtSetting.SectionName)
                .ValidateDataAnnotations()
                .ValidateOnStart();


            var jwtSettings = config.GetSection(JwtSetting.SectionName).Get<JwtSetting>();


            if (jwtSettings == null)
                throw new InvalidOperationException("Jwt settings not found");

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                    ClockSkew = TimeSpan.Zero
                };
            });


            builder.Services.AddAuthorization();
            return builder;
        }

        public static WebApplication UseJwtBasedAuthentication(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthentication();

            return app;
        }


    }
}
