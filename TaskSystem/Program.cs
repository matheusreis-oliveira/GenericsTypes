using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repository;
using TaskSystem.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<TaskDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("TaskBase"))
    );

builder.Services.AddScoped<ICrudRepository<User>, CrudRepository<User>>();
builder.Services.AddScoped<ICrudRepository<Tasks>, CrudRepository<Tasks>>();

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