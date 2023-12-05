using Microsoft.EntityFrameworkCore;
using Vegan.api.Data;
using Vegan.api.Models;
using Vegan.api.Services;
using Vegan.api.Repositories;
using Vegan.api;


var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

/*builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultMySQLConnection");
    var serverVersion = new ServerVersion(new Version(, 0, 33));
    options.UseMySql(connectionString, serverVersion);
}); */


builder.Services.AddDbContext<DataContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ConexaoLocal");

    // Use a versão padrão do MySQL Server
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

}); 


// Add services to the container.


builder.Services.AddCors();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
app.Run();
