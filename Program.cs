using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RotinaDiaria.Config;
using RotinaDiaria.Repository;  // Adicionando o namespace do CompromissoRepository

var builder = WebApplication.CreateBuilder(args);

// Configurar MongoDB
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDBConfig>();

// Adicionando Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionando o repositório de compromissos
builder.Services.AddSingleton<CompromissoRepository>();

// Adicionando o serviço de controladores
builder.Services.AddControllers();  // <--- Adicionando esse serviço

// Adicionando o serviço de autorização
builder.Services.AddAuthorization();

var app = builder.Build();

// Configurar o pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();  // Agora os controladores serão mapeados corretamente

app.Run();
