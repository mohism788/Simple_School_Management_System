using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using School_Management_System.DataAccess;
using School_Management_System.Models;
using School_Management_System.Repositories;
using School_Management_System.Repositories.CoursesRepository;
using School_Management_System.Repositories.GenericRepository;
using School_Management_System.Repositories.SuppliesRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Management API", Version = "v1" });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
builder.Services.AddScoped<ISuppliesRepository, SuppliesRepository>();
builder.Services.AddScoped<IGenericRepository<Student>, GenericRepository<Student>>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//if isDevelopment app run swagger



app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
