using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using PrologMobile.Models;
using PrologMobile.Services;
using Microsoft.OpenApi.Models; // Add this for Swagger

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container.
builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("YourConnectionStringName")));

builder.Services.AddScoped<OrganizationService>();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PrologMobile API", Version = "v1" });
});

var app = builder.Build();

// Use Swagger middleware to serve generated Swagger as a JSON endpoint.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // Use Swagger UI middleware to serve Swagger UI at /swagger.
    // Visit /swagger/index.html to see the UI.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PrologMobile API V1");
    });
}

// Define a minimal API endpoint
app.MapGet("/organizations/summary", (OrganizationService service) =>
{
    return service.GetOrganizationsSummary();
});

app.Run();
