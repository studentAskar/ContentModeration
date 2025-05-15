using Application;
using Domain.Interfaces;
using Infrastructure;
using Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapHub<QueueHub>("/queuehub");

// ��������� ������� � �����������
var storagePath = Path.Combine(builder.Environment.WebRootPath, "videos");
if (!Directory.Exists(storagePath))
{
    Directory.CreateDirectory(storagePath);
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
