using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Projecthoca.Data;
using Projecthoca.Helper;
using Projecthoca.Models.Enitity;
using Projecthoca.Service.Interface;

using Projecthoca.Service.Responser;
using System.Threading;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyDbcontext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 100, // Số lần thử lại tối đa
                maxRetryDelay: TimeSpan.FromSeconds(30), // Thời gian chờ tối đa giữa các lần thử lại
                errorNumbersToAdd: null); // Có thể chỉ định mã lỗi cụ thể để thử lại
        }));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
     .AddEntityFrameworkStores<MyDbcontext>()
     .AddDefaultTokenProviders();
builder.Services.AddAuthorization(options =>
{

    options.AddPolicy("Customer", policy => policy.RequireRole("Customer"));
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Home/Dangnhap";
    options.AccessDeniedPath = "/Home/Loi404";
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Home/Dangnhap";
            options.LogoutPath = "/Home/Dangnhap";
            options.Cookie.HttpOnly = true;
            options.Cookie.Expiration = TimeSpan.FromDays(1);
            options.SlidingExpiration = true;
        });
builder.Services.AddMemoryCache();
builder.Services.AddScoped<INguoidung, NguoidungReponser>();
builder.Services.AddSignalR();
builder.Services.AddScoped<IHoca, HocaReponser>();
builder.Services.AddScoped<IKhuvuccau, KhuvuccauReponser>();
builder.Services.AddScoped<IDanhmuc, DanhmucReponser>();
builder.Services.AddScoped<IGiahoca, GiahocaReponser>();
builder.Services.AddScoped<IChitietca, ChitietcaReponser>();
builder.Services.AddScoped<IDanhmuchoadon, DanhmuchoadonReponser>();
builder.Services.AddScoped<IThongbao, ThongbaoReponser>();
builder.Services.AddScoped<IPhieuxuatkho, PhieuxuatkhoReponser>();
builder.Services.AddScoped<IBanle, BanleReponser>();
builder.Services.AddScoped<IKhachhang, KhachhangReponser>();
builder.Services.AddScoped<ITonkho, TonkhoReponser>();
builder.Services.AddSingleton<TimerBackgroundService>();
builder.Services.AddHostedService<TimerBackgroundService>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddLogging();

// Thêm dịch vụ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project API", Version = "v1" });
});


var app = builder.Build();


// Cấu hình Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project API V1");
    });
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Loi404");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Use(async (context, next) =>
{
    context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
    context.Response.Headers["Pragma"] = "no-cache";
    context.Response.Headers["Expires"] = "0";
    await next();
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Dangnhap}/{id?}");
    endpoints.MapHub<Timehub>("/Timehub"); // Map SignalR Hub
});

app.Run();
