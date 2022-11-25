using Human.Resources.API.Domain.Interfaces;
using Human.Resources.API.Domain.Services;
using Human.Resources.API.Infraestructure.Repositories;
using Human.Resources.API.Infraestructure.Utilities;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
builder.Services.Configure<Settings>(configuration);

//Services
builder.Services.AddTransient<IWorkerServices, WorkerServices>();

//Repositories
builder.Services.AddTransient<IWorkerRepository, WorkerRepository>();
builder.Services.AddTransient<IWorkerTitleRepository, WorkerTitleRepository>();
builder.Services.AddTransient<ILoginServices, LoginServices>();
builder.Services.AddTransient<ILoginRepository, LoginRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
