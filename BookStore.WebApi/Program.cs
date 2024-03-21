using Microsoft.EntityFrameworkCore;
using BookStore.WebApi.Data;
using BookStore.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ProjectNameDb"));

builder.Services.AddCustomServices();
builder.Services.AddRepositories();
builder.Services.AddAutoMapper();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
