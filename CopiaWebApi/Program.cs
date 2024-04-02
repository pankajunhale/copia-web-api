using CopiaWebApi.Controllers;
using CopiaWebApi.Db;
using CopiaWebApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register the DbContext
builder.Services.AddDbContext<PaybrijDbContext>(options =>
    options.UseSqlite("Data Source=Reference.db;Mode=ReadWriteCreate"));

builder.Services.AddScoped<InputFileService, InputFileService>();
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

app.MapTodoEndpoints();

app.Run();
