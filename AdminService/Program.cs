using AdminService.DIServices;
using BussinessLogic.DataRepository;
using Data.DataContext.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
//Add services to the container.
builder.Services.AddDbContext<DbProjectContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

ConfigureMediatRHandler.RegisterHandler(builder.Services);

//Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers();

ConfigureServices.RegisterServices(builder.Services);

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
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapGrpcService<AdminService.OrganizationService>();
});

app.UseCors("CORSPolicy");

//app.UseAuthorization();

app.MapControllers();

app.Run();
