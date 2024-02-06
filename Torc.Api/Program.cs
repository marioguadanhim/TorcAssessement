using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Torc.BLL.Services;
using Torc.DAL.EntityFramework;
using Torc.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI Container

builder.Services.AddTransient<BookServices>();
builder.Services.AddTransient<BookRepository>();
builder.Services.AddTransient<BookLibraryContext>();

#endregion

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
