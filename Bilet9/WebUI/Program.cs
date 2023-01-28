using Core.Entities;
using DataAccess.Contexts;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebUI.Utilites;

var builder = WebApplication.CreateBuilder(args);

var connect = builder.Configuration["ConnectionStrings:Default"];
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
	opt.UseSqlServer(connect);
});


builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
	opt.Password.RequiredLength = 8;
	opt.Password.RequireDigit = true;
	opt.Password.RequireLowercase = true;
	opt.Password.RequireUppercase = true;
	opt.Password.RequireNonAlphanumeric = true;


	opt.User.RequireUniqueEmail = true;

	opt.Lockout.MaxFailedAccessAttempts = 5;
	opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(10);
	opt.Lockout.AllowedForNewUsers = true;
}).AddEntityFrameworkStores < AppDbContext>()
  .AddDefaultTokenProviders();//forgot password ucun

builder.Services.AddSession(opt =>
{
	opt.IdleTimeout = TimeSpan.FromSeconds(15);
});

builder.Services.ConfigureApplicationCookie(opt =>
{
	opt.LoginPath = "/Auth/Login";
});


//email Sender
//var emailConfig = builder.Configuration
//	.GetSection("EmailConfiguration")
//	.Get<EmailConfiguration>();
//services.AddSingleton(emailConfig);
//services.AddScoped<IEmailSender, EmailSender>();

//Constants.EmailAddress = builder.Configuration["Gmail:MailAddress"];
//Constants.Password = builder.Configuration["Gmail:Password"];


builder.Services.AddScoped< IIntroductionRepository, IntroductionRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{Id?}"
);
app.Run();
