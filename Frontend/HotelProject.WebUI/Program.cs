using HotelProject.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Concrete;
using FluentValidation.AspNetCore;
using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//AddFluentValidation'u biz ekledik.
builder.Services.AddControllersWithViews().AddFluentValidation();
//Validation iþlemi için bunu eklememiz gerekiyor.
builder.Services.AddTransient<IValidator<CreateGuestDto>, CreateGuestValidator>();
builder.Services.AddTransient<IValidator<UpdateGuestDto>, UpdateGuestValidator>();

//HttpClient ekledik
builder.Services.AddHttpClient();
//AutoMapper ekledik
builder.Services.AddAutoMapper(typeof(Program));
//Register kýsmý için servislerimizi ekledik
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
