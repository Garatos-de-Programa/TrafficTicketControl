using TrafficTicket.Api.Data;
using TrafficTicket.Api.Repositories;
using TrafficTicket.Api.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITrafficFineContext, TrafficFineContext>();
builder.Services.AddScoped<ITrafficViolationContext, TrafficViolationContext>();
builder.Services.AddScoped<IUserContext, UserContext>();
builder.Services.AddScoped<ITrafficViolationRepository, TrafficViolationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITrafficFineRepository, TrafficFineRepository>();

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
