using TaskFlow.Web.Services;
using TaskFlow.Web.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<ITaskService, InMemoryTaskService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

// redirects the application to https port of the application
app.UseHttpsRedirection();
//uses the static files -> png, jpg
app.UseStaticFiles();
// built in routing
app.UseRouting();

app.MapRazorPages();


app.Run();
