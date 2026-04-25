using Microsoft.EntityFrameworkCore;
using Online_Store_Backend_WebAPI.Repositories.Abstractions;
using Online_Store_Backend_WebAPI.Repositories.Implementations;
using Online_Store_Backend_WebAPI.Services.Abstractions;
using Online_Store_Backend_WebAPI.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

var cs = builder.Configuration.GetConnectionString("SteamStore")
    ?? throw new InvalidOperationException("Connection string 'SteamStore' was not found.");

builder.Services.AddDbContext<global::Online_Store_Backend_WebAPI.DB.AppContext>(options =>
    options.UseMySql(cs, ServerVersion.AutoDetect(cs)));
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGameService, GameService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
