using Microsoft.EntityFrameworkCore;
using allias = MovieService.src.MovieService.Application.Services;
using MovieService.src.MovieService.Application.Services.Abstraction;
using MovieService.src.MovieService.Infrastructure.Data;
using MovieService.src.MovieService.Infrastructure.Repositores;
using MovieService.src.MovieService.Infrastructure.Repositores.Abstraction;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("InMem"));

builder.Services.AddScoped<IMovieRepositroy, MovieRepository>();
builder.Services.AddScoped<IMovieService,  allias.MovieService>();

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
