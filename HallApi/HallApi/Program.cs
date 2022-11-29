using HallDal;
using HallDal.Repositories;
using HallDomain.Interfaces;
using HallDomain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IHallService, HallService>();

builder.Services.AddScoped<IHallRepository,HallRepository>();

builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();

//builder.Services.AddSingleton;
//builder.Services.AddTransient;

builder.Services.AddDbContext<FuwearContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
