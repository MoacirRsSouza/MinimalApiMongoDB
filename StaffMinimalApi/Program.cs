using Microsoft.OpenApi.Models;
using StaffMinimalApi.Data;
using StaffMinimalApi.Data.Context;
using StaffMinimalApi.Data.Repository;
using StaffMinimalApi.MapEndpoint;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI 
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",new OpenApiInfo { Title = "Staff API", Version = "v1" });
});

builder.Services.Configure<MongoConfiguration>(builder.Configuration.GetSection("MongoConfiguration"));

builder.Services.AddSingleton<IStaffContext, StaffContext>();
builder.Services.AddSingleton<IStaffRepository, StaffRepository>();

var app = builder.Build();
app.MapStaffEndpoints();

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
