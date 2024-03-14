using Microsoft.EntityFrameworkCore;
using Samsys_Book_Practice.Interfaces.Books;
using Samsys_Book_Practice.Mappings;
using Samsys_Book_Practice.Models;
using Samsys_Book_Practice.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//INJECAO DE DEPENDENCIA
//Adicionar serviço e repositório
//builder.Services.AddDbContextFactory<BookContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

//AutoMapper - Book para BookDTO
builder.Services.AddAutoMapper(typeof(EntityToDTOMappingProfile));


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
