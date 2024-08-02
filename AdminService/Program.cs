using AdminService.DIServices;
using BussinessLogic.DataRepository;
using Data.DataContext.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel server options
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(4501, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1;
    });
});

// Add services to the container
builder.Services.AddGrpc();
builder.Services.AddDbContext<DbProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

ConfigureMediatRHandler.RegisterHandler(builder.Services);

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Add controllers
builder.Services.AddControllers();

ConfigureServices.RegisterServices(builder.Services);

// Register CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configure Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

// Apply CORS policy between UseRouting and UseEndpoints
app.UseCors("CORSPolicy");

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapGrpcService<AdminService.OrganizationService>();
    _ = endpoints.MapGrpcService<AdminService.LoginService>();
    _ = endpoints.MapGrpcService<AdminService.RegisterService>();
    _ = endpoints.MapControllers(); // Ensure controllers are mapped within endpoints
});

app.Run();


//using AdminService.DIServices;
//using BussinessLogic.DataRepository;
//using Data.DataContext.Models;
//using Microsoft.AspNetCore.Server.Kestrel.Core;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(5002, listenOptions =>
//    {
//        listenOptions.Protocols = HttpProtocols.Http1;
//    });
//});
//builder.Services.AddGrpc();
////Add services to the container.
//builder.Services.AddDbContext<DbProjectContext>(options =>
//           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//ConfigureMediatRHandler.RegisterHandler(builder.Services);

////Register AutoMapper
//builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//builder.Services.AddControllers();

//ConfigureServices.RegisterServices(builder.Services);

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();



//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    _ = endpoints.MapGrpcService<AdminService.OrganizationService>();
//    _ = endpoints.MapGrpcService<AdminService.LoginService>();
//    _ = endpoints.MapGrpcService<AdminService.RegisterService>();
//});

//app.UseCors("CORSPolicy");

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
