using Microsoft.EntityFrameworkCore;
using MovieSeries.DataAccessLayer;
using MovieSeries.DataAccessLayer.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ cho Controller
builder.Services.AddControllers();

// Cấu hình kết nối SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(@"Server=TUS-B52;Database=QLMV;User Id=TUS-B52\Admin;TrustServerCertificate=True"));

// Thêm Swagger (OpenAPI)
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build(); // ✅ Gọi Build() sau khi đăng ký toàn bộ service

// Cấu hình Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
