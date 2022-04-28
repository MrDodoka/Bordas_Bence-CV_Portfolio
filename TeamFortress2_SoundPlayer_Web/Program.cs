using Microsoft.EntityFrameworkCore;
using TeamFortress2_SoundPlayer_Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<VoiceLinesDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("TestServerConnection")
    ));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
