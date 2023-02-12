using Microsoft.OpenApi.Models;
using UserManagment.Infrastructure;
using UserManagmentEventSsore.Commands;
using UserManagmentEventSsore.Commands.Commands;
using UserManagmentEventStore.Queries.Queries;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IQueriesService, QueriesService>();

//Implement Infrasture DependencyInjection Container
builder.Services.ImplementPersistence(builder.Configuration);
builder.Services.Register();

builder.Services.AddControllers();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
