using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using MyShop.Core;
using MyShop.Persistence;
using MyShop.Web;
using MyShop.Web.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebDependencies(builder.Configuration)
    .AddApplicationCore()
    .AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseHttpsRedirection();

app.UseSpaStaticFiles();

app.UseCustomExceptionHandler();

app.UseRouting();
app.UseCors();
app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(builder =>
{
    builder.MapControllerRoute(
        name: "api",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";
    //if (builder.Environment.IsDevelopment())
    //{
    //    spa.UseAngularCliServer(npmScript: "start");
    //}
});

app.Run();
