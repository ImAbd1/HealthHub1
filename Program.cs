using HealthHub1.Data;
using HealthHub1.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<BedService>();
builder.Services.AddScoped<NurseService>();
builder.Services.AddScoped<DoctorService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// Add session services
builder.Services.AddDistributedMemoryCache(); // Required for session
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set timeout
    options.Cookie.HttpOnly = true; // Security settings
    options.Cookie.IsEssential = true; // Required for GDPR compliance
});

var app = builder.Build();

//Seed.SeedData(app);

if (args.Length == 1 && args[0].ToLower() == "seeddata") {
    Seed.SeedData(app);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Required for session

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
