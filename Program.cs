using Microsoft.EntityFrameworkCore;
using ZeFiveNime.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ZeFiveNimeDbContext>(options => 
options.UseNpgsql(connectionstring));

// Add services to the container.
builder.Services.AddControllers();
// Menambahkan Interface dan Repository
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IAnimationRepository,AnimationRepository>();

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
