using Microsoft.EntityFrameworkCore;
using ReactApp1.Server.Model;
using ReactApp1.Server.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//var connString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ContextFile>(options =>
//    options.UseSqlServer(connString));
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ContextFile>(options =>
    options.UseSqlServer(connString));

builder.Services.AddScoped<ITenantRepository, TenantRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {

        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
