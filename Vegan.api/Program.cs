using Microsoft.EntityFrameworkCore;
using Vegan.api.Data;
using Vegan.api.Repositories.Fornecedores;
using Vegan.api.Repositories.PratosRestaurantes;
using Vegan.api.Repositories.Produtos;
using Vegan.api.Repositories.Restaurantes;
using Vegan.api.Repositories.Unit_of_Work;
using Vegan.api.Services.Fornecedores;
using Vegan.api.Services.PratosRestaurantes;
using Vegan.api.Services.Produtos;
using Vegan.api.Services.Restaurantes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal"));
});

builder.Services.AddScoped<IFornecedoresRepository, FornecedoresRepository>();
builder.Services.AddScoped<IFornecedoresService, FornecedoresService>();

// Adiciona os serviços para PratosRestaurantes
builder.Services.AddScoped<IPratosRestaurantesRepository, PratosRestaurantesRepository>();
builder.Services.AddScoped<IPratosRestaurantesService, PratosRestaurantesService>();

// Adiciona os serviços para Produtos
builder.Services.AddScoped<IProdutosRepository, ProdutosRepository>();
builder.Services.AddScoped<IProdutosService, ProdutosService>();



// Adiciona os serviços para Restaurantes
builder.Services.AddScoped<IRestaurantesRepository, RestaurantesRepository>();
builder.Services.AddScoped<IRestaurantesService, RestaurantesService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling =
Newtonsoft.Json.ReferenceLoopHandling.Ignore
);*/

var app = builder.Build();

// Configurações do Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);


app.UseHttpsRedirection();
app.UseAuthorization();




app.MapControllers();

app.Run();
