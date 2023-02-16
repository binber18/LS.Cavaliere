using LS.Cavaliere.AspNetCore.TagHelpers;
using Microsoft.EntityFrameworkCore;
using LS.Cavaliere.EntityFrameworkCore;
using LS.Cavaliere.Helpers;
using LS.Cavaliere.Models;
using LS.Cavaliere.Repositories.AzureStorage;
using LS.Cavaliere.Serilog;
using LS.Cavaliere.Services;
using LS.Cavaliere.Services.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog();

builder.Services.AddEntityFrameworkCore(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection").AssertNotNull());
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEntityFrameworkIdentity(options => {
    options.SignIn.RequireConfirmedAccount = true;
});
builder.Services.ConfigureApplicationCookie(o => {
    o.LoginPath = "/Admin/Login";
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Repositories
builder.Services
       .AddAzureStorage(builder.Configuration.GetConnectionString("AzureStorage").AssertNotNull());

//Services
builder.Services
       .AddIdentityServices()
       .AddCavaliereServices();

builder.Services
       .AddTagHelpers();

var app = builder.Build();

app.UseSerilog();

await app.Services.SeedDefaultAdmin(app.Configuration.GetSection("DefaultAdmin").Get<DefaultAdmin>().AssertNotNull());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
   .RequireAuthorization();
app.MapRazorPages();

app.Run();