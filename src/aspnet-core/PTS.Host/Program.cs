using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PTS.EntityFrameworkCore.Repository.IRepository;
using PTS.EntityFrameworkCore.Repository;
using PTS.Host;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using PTS.EntityFrameworkCore;
using PTS.Host.Repository;
using PTS.Domain.Entities;
using PTS.Host.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
//#region Đăng ký DI
builder.Services.AddScoped<ApplicationDbContext, ApplicationDbContext>();

builder.Services.AddTransient<IRamRepository, RamRepository>();

builder.Services.AddTransient<IAllRepository<CpuEntity>, AllRepository<CpuEntity>>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(options =>
//{
//    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
//    {
//        In = ParameterLocation.Header,
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey
//    });

//    options.OperationFilter<SecurityRequirementsOperationFilter>();
//});
//builder.Services.AddAuthentication().AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        ValidateAudience = false,
//        ValidateIssuer = false,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"))
//    };
//});

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
