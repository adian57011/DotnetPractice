var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();


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



app.MapGet("/", () => "Hello World!");

app.Run();
