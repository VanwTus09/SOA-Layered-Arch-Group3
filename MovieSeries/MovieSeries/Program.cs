using Microsoft.EntityFrameworkCore;
using MovieSeries.DataAccessLayer;
using MovieSeries.CoreLayer.Interfaces;
using MovieSeries.DataAccessLayer;
using MovieSeries.ServiceLayer;
using MovieSeries.ServiceLayer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=LAPTOP-TIH7GM6J\\MSSQLSERVERCSDL;Database=QLMV;Integrated Security=True;TrustServerCertificate=True"));
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<MovieService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

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
