using LessonAspIdentity18.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("myconn")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<UContext>();
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizePage("/AdminPage");
});
builder.Services.ConfigureApplicationCookie(o =>
{
    //cookie tohirgoo
    o.Cookie.HttpOnly = true;
    o.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    o.LoginPath = "/Login";
    o.AccessDeniedPath = "/Index";
    o.SlidingExpiration = true;
});
builder.Services.Configure<IdentityOptions>(options =>
{
    //password tohirgoo
    //nuuts ug hamgiin bagadaa 6 usegtei bna
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit=true;//zaaval too aguulsan bna
    options.Password.RequireLowercase=true;//zaabal jijig useg aguulsan bna
    options.Password.RequiredUniqueChars = 1;//zaaval neg temdegt
    options.Password.RequireUppercase=true; //zaaval tom useg aguulsan bna  
    //lockout tohirgoo
    options.Lockout.MaxFailedAccessAttempts = 5;//login hiih oroldlogiin too
    //lock bolson hereglech huleeh hugatsaa
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.AllowedForNewUsers = true;
    //user tohirgoo
    options.User.RequireUniqueEmail = false;
    options.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234568790@.-_";
});
var app = builder.Build();
app.MapRazorPages();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.Run();