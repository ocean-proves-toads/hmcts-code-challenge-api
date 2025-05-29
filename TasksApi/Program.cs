using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TasksApi.DbContexts;
using TasksApi.Services;

// CORS Settings
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Add swagger documentation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MojTasks",
        Version = "v1"
    });
});

builder.Services.AddDbContext<MojTasksContext>(options =>
    options.UseSqlite(
        builder.Configuration["ConnectionStrings:MojTasksConnectoinString"]));

builder.Services.AddScoped<IMojTasksRepository, MojTasksRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MojTasks v1"));
    app.UseCors(MyAllowSpecificOrigins);
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();

app.Run();