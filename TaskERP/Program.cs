using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using TaskERP.BLL;
using TaskERP.BLL.Interface;
using TaskERP.BLL.Mapper;
using TaskERP.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();

// AutoMapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequireUppercase = true;
	options.Password.RequiredLength = 5;
	options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationContext>()
.AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
	options.LoginPath = new PathString("/Account/Login");
	options.AccessDeniedPath = new PathString("/Home/NotFound");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/NotFound");
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
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
