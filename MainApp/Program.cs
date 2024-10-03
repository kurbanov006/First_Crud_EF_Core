using Infrastructure.DataContext;
using Infrastructure.Services;
using MainApp.Controllers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddDbContext<AppDbContext>(p =>
    p.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        b=>b.MigrationsAssembly("MainApp")));

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger(); 
app.UseSwaggerUI();

app.MapControllers();

app.Run();