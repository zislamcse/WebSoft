using Microsoft.EntityFrameworkCore;
using WebSoft.API.DbHelper;
using WebSoft.API.Mapping;
using WebSoft.API.Repositories.Interface;
using WebSoft.API.Repositories.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conString")));

builder.Services.AddScoped<IProductType, SProductType>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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
