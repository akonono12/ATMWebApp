using ATMWebApp.Domain.ATMManagement;
using ATMWebApp.Domain.ATMManagement.Entities;
using ATMWebApp.Domain.ATMManagement.Interfaces;
using ATMWebApp.Domain.ATMManagement.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;


static void AddCustomerData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<ATMManagementDBContext>();

    db.Accounts.Add(new Account("Leo Gem", 9999, 1234, "pass123"));
    db.Accounts.Add(new Account("Ares Tau", 99999, 4321, "pass321"));
    db.Accounts.Add(new Account("Virgo Pi", 999999, 678901, "pass789"));
    db.SaveChanges();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var assembly = AppDomain.CurrentDomain.Load("ATMWebApp.Application");
builder.Services.AddMediatR(assembly);
builder.Services.AddDbContext<ATMManagementDBContext>
(o => o.UseInMemoryDatabase("ATMDB"));
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddScoped<IATMRepository, ATMRepository>();
builder.Services.AddTransient<ATMManagementDBContext>();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
AddCustomerData(app);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseCors("corsapp");
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
