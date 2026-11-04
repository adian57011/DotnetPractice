using Microsoft.EntityFrameworkCore;
using MinimalApi.Data;
using MinimalApi.Repository;
using MinimalApi.ResponseExtension;
using Shared.Extension;
using Utilities.Response;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterSwagger();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});



builder.Services.AddScoped<UserRepository>();


// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseRegisteredSwagger();

app.MapGet("health", () =>
{
    var res = ApiResponse<object>.Fail();
    return res.ToResult();
});

app.Run();

