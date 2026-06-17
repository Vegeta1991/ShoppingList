/*using Microsoft.EntityFrameworkCore;
using ShoppingList.Data;
using ShoppingList.Repositories;


var builder = WebApplication.CreateBuilder(args);

//DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Without json =>options.UseSqlite("Data Source=C:\\Users\\KAS\\source\\repos\\ShoppingList\\ShoppingList.db")

builder.Services.AddScoped<ShoppingRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();// End points API Explorer for API documentation and testing
builder.Services.AddSwaggerGen(); // End points API Explorer and Swagger for API documentation and testing


var conn = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("CONFIG DB:");
Console.WriteLine(conn);
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    Console.WriteLine("DB CONNECTION:");
    Console.WriteLine(context.Database.GetDbConnection().ConnectionString);

    Console.WriteLine("DB PATH:");
    Console.WriteLine(context.Database.GetDbConnection().DataSource);
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}// Enable Swagger and Swagger UI in development environment for API documentation and testing

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();



app.Run();*/
using Microsoft.EntityFrameworkCore;
using ShoppingList.Data;
using ShoppingList.Repositories;

var builder = WebApplication.CreateBuilder(args);

// DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ShoppingRepository>();

// MVC
builder.Services.AddControllersWithViews();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// DEV tools
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();


// 🔥 STATYKA (TO JEST KLUCZ)
app.UseDefaultFiles();   // "/" -> index.html
app.UseStaticFiles();    // wwwroot

app.UseRouting();

app.UseAuthorization();

// MVC routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



