using YouBikeNow.Helpers;
using YouBikeNow.Interfaces;
using YouBikeNow.Services;

var builder = WebApplication.CreateBuilder(args);

// Register IHttpClientFactory
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddHttpClient<YouBikeOpenAPIHelper>();
builder.Services.AddScoped<IYouBikeService, YouBikeService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
