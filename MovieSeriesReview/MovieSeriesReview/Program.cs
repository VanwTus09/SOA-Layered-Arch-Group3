using Microsoft.EntityFrameworkCore;
using MovieSeriesReview.CoreLayer.Interfaces;
using MovieSeriesReview.DataAccessLayer;
using MovieSeriesReview.ServiceLayer;
using MovieSeriesReview.ServiceLayer.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer("Server=LAPTOP-TIH7GM6J\\MSSQLSERVERCSDL;Database=QLMV;User Id=LAPTOP-TIH7GM6J\\Nhan;TrustServerCertificate=True"));
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<MovieService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
//builder.Services.AddScoped<IMovieService, MovieService>();

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
