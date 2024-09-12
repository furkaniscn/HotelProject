using HotelProject.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Concrete;
using FluentValidation.AspNetCore;
using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//AddFluentValidation'u biz ekledik.
builder.Services.AddControllersWithViews().AddFluentValidation();
//Validation i�lemi i�in bunu eklememiz gerekiyor.
builder.Services.AddTransient<IValidator<CreateGuestDto>, CreateGuestValidator>();
builder.Services.AddTransient<IValidator<UpdateGuestDto>, UpdateGuestValidator>();

//HttpClient ekledik
builder.Services.AddHttpClient();
//AutoMapper ekledik
builder.Services.AddAutoMapper(typeof(Program));
//Register k�sm� i�in servislerimizi ekledik
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
//Authorization i�lemi i�in yapt���m�z k�s�m.
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
//Authorization yap�l�rken belirli �eyleri kendimize g�re ayarlad�k.
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.LoginPath = "/Login/Index/";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseAuthentication();//Authentication i�in biz ekledik.

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");//Error sayfas�n� �zelle�tirmek i�in biz ekledik.
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
