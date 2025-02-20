using Microsoft.EntityFrameworkCore;
using MovieSeries.DataAccessLayer;
using MovieSeries.RepositoryLayer.Interfaces;
using MovieSeries.RepositoryLayer;
using MovieSeries.ServiceLayer.Interfaces;
using MovieSeries.ServiceLayer.Services;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
// Thêm dòng này để đăng ký IDbConnection
builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection("Server=TUS-B52;Database=QLMV;Integrated Security=True;TrustServerCertificate=True")
);
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=TUS-B52;Database=QLMV;Integrated Security=True;TrustServerCertificate=True"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Đăng ký repository
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRatingRepository, RatingRepository>();

// Đăng ký service
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRatingService, RatingService>();

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
