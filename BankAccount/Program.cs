using BankAccount.Backend.DAL.Interfaces;
using BankAccount.Backend.DAL.Repositories;
using BankAccount.Backend.DAL;
using BankAccount.Backend.Domain.Entity;
using BankAccount.Backend.Services.Implementations;
using BankAccount.Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBaseRepository<AccountEntity>, AccountRepository>();
builder.Services.AddScoped<IBaseRepository<ClientEntity>, ClientRepository>();
builder.Services.AddScoped<IBaseRepository<LegalUserEntity>, LegalUserRepository>();
builder.Services.AddScoped<IBaseRepository<PhisycalUserEntity>, PhisycalUserRepository>();
builder.Services.AddScoped<IBaseRepository<PaymentEntity>, PaymentRepository>();
builder.Services.AddScoped<IBaseRepository<InterestRateEntity>, InterestRateRepository>();
builder.Services.AddScoped<IBankService, BankService>();

var connectionString = builder.Configuration.GetConnectionString("MSSQL");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
