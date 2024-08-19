using Microsoft.EntityFrameworkCore;
using Examen2.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
new MySqlServerVersion(new Version(8, 0, 25))));


builder.Services.AddRazorPages();

var app = builder.Build();


app.Urls.Add("http://localhost:5000");
app.Urls.Add("https://localhost:5001");

foreach (var url in app.Urls)
{
    Console.WriteLine($"La aplicación se está ejecutando en: {url}");
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        dbContext.Database.CanConnect();
        Console.WriteLine("Conexión a la base de datos exitosa.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error de conexión a la base de datos: {ex.Message}");
        throw;

    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
