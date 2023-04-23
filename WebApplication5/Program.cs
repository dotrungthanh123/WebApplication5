using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication5.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebApplication5.Models;
using Microsoft.AspNetCore.Authentication.Google;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApplication5Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectString") ?? throw new InvalidOperationException("Connection string 'WebApplication5Context' not found.")));

builder.Services.AddRazorPages();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("IsRetailer", o => o.RequireRole("3"));
    o.AddPolicy("IsAdmin", o => o.RequireRole("1"));
    o.AddPolicy("IsCustomer", o => o.RequireRole("2"));
});

builder.Services.AddAuthentication(o =>
{
    o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    //o.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
}).AddCookie(o =>
{
    //o.Cookie.SameSite = SameSiteMode.Strict;
}).AddGoogle(o =>
{
    o.ClientId = "540068662364-vc80jl5qonvk1pnioistb2jf0uaegec1.apps.googleusercontent.com";
    o.ClientSecret = "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";
});


builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
