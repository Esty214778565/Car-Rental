using CarRental.Core;
using CarRental.Core.Entities;
using CarRental.Core.IRepository;
using CarRental.Core.IService;
using CarRental.Data;
using CarRental.Data.Repository;
using CarRental.Service;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRepository<UserEntity>, UserRepository>();

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IRepository<CarEntity>, CarRepository>();

builder.Services.AddScoped<ICollectionPointService, CollectionPointService>();
builder.Services.AddScoped<IRepository<CollectionPointEntity>, CollectionPointRepository>();

builder.Services.AddScoped<IInvitationService, InvitationService>();
builder.Services.AddScoped<IRepository<InvitationEntity>, InvitationRepository>();
builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer(
     
        "Data Source=DESKTOP-1VUANBN;Initial Catalog=CarRental;Integrated Security=true;");
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfile));//check?
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
