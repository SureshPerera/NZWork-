using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NZWork.API.Data;
using NZWork.API.Mappings;
using NZWork.API.Repositories;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NZWalksDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NZWolkConnectionString")));

//builder.Services.AddDbContextFactory<NZWalksDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnectionString") ?? throw new InvalidOperationException("Connection string 'NZWalksConnectionString' not found.")));

builder.Services.AddScoped<IRegionsRepository,SqlRegionRepository>();
builder.Services.AddScoped<IWorkRepository,SqlWorksRepository>();
//builder.Services.AddAutoMapper(typeof(AutomapperProfiles));

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
