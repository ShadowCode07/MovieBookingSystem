using Microsoft.EntityFrameworkCore;
using allias = UserService.src.UserServices.Application.Services;
using UserService.src.UserServices.Application.Services.Abstraction;
using UserService.src.UserServices.Infrastructure.Data;
using UserService.src.UserServices.Infrastructure.Data.Repositories;
using UserService.src.UserServices.Infrastructure.Data.Repositories.Abstarction;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("InMem"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, allias.UserService>();

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

