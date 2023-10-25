using Megalon.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//self //mysql connection and location
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CustomerOrdersDB>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 22))));



var app = builder.Build();



//self  //migration
using (var scope = app.Services.CreateScope())
{
    try
    {
        var serviceProvider = scope.ServiceProvider;
        var context = serviceProvider.GetRequiredService<CustomerOrdersDB>();
        context.Database.Migrate();
    }catch(Exception e)
    {

    }
}

//migration(self)
// Apply pending migrations(its creating/updating database automatically as similiar in hibernate)
using (var scope = app.Services.CreateScope())
{
    try
    {
        var serviceProvider = scope.ServiceProvider;
        var context = serviceProvider.GetRequiredService<CustomerOrdersDB>();
        context.Database.Migrate();
    }
    catch(Exception e) { }
}



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
