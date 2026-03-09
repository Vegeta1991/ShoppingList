using Microsoft.EntityFrameworkCore;
using ShoppingList.Data;


var builder = WebApplication.CreateBuilder(args);

//DB Context
builder.Services.AddDbContext<AppDbContext>(options 
    => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Without json =>options.UseSqlite("Data Source=C:\\Users\\KAS\\source\\repos\\ShoppingList\\ShoppingList.db")


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
