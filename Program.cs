using Microsoft.EntityFrameworkCore;
using krogercart.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register the AppDbContext with the dependency injection container, using the connection string from the configuration.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ProductConnection")));

var app = builder.Build();

// Seed Data 
using (var scope = app.Services.CreateScope())
{
    SeedData.Initialize(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. Consider changing this for production.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();