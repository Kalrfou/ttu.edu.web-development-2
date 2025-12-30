using GuitarManager.data;
using GuitarManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Connection string
var connectionString = builder.Configuration.GetConnectionString("GuitarDbContextConnection")
    ?? throw new InvalidOperationException("Connection string 'GuitarDbContextConnection' not found.");

// Database
builder.Services.AddDbContext<GuitarDbContext>(options =>
    options.UseSqlServer(connectionString));

// MVC + Razor Pages
builder.Services.AddControllersWithViews();   // ✅ REQUIRED
builder.Services.AddRazorPages();             // ✅ REQUIRED FOR IDENTITY

// Identity
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<GuitarDbContext>();

var app = builder.Build();

// Error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();        // ✅ REQUIRED

app.UseRouting();

app.UseAuthentication();     // 🔑 FIRST
app.UseAuthorization();      // 🔐 SECOND

// MVC routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Guitars}/{action=Index}/{id?}");

// Razor Pages routing (IDENTITY)
app.MapRazorPages();         // 🔑 REQUIRED

app.Run();
