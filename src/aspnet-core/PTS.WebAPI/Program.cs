using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Services;
using PTS.Data;
using PTS.Persistence.Repositories;
using PTS.Persistence.Repository;
using PTS.Persistence.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using PTS.Application.Extensions;
using PTS.Persistence.Extensions;
using PTS.Application.Features.Cart.Queries;
using Microsoft.AspNetCore.Identity;
using PTS.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
	option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//builder.Services.AddIdentity<UserEntity, RoleEntity>()
//	.AddEntityFrameworkStores<ApplicationDbContext>()
//	.AddDefaultTokenProviders();

builder.Services.AddIdentityApiEndpoints<UserEntity>().AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddAuthentication(options =>
//{
//	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//	options.TokenValidationParameters = new TokenValidationParameters
//	{
//		ValidateIssuer = true,
//		ValidateAudience = true,
//		ValidateLifetime = true,
//		ValidateIssuerSigningKey = true,
//		ValidIssuer = builder.Configuration["Jwt:Issuer"],
//		ValidAudience = builder.Configuration["Jwt:Issuer"],
//		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//	};
//});

//IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddApplicationLayer(builder.Configuration);
//builder.Services.AddInfrastructureLayer();
builder.Services.AddPersistenceLayer(builder.Configuration);
//builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
#region Đăng ký MediatR
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(PagingListVoucherRequestHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCartByUserHandler).Assembly));
#endregion
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "api.phuongthaoshop.vn", Version = "v1" });
	var filePath = Path.Combine(Directory.GetCurrentDirectory(), "api.phuongthaoshop.vn.xml");
	c.IncludeXmlComments(filePath);
});
//builder.Services.AddSwaggerGen(options =>
//{
//	options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
//	{
//		In = ParameterLocation.Header,
//		Name = "Authorization",
//		Type = SecuritySchemeType.ApiKey
//	});

//	options.OperationFilter<SecurityRequirementsOperationFilter>();
//});
//builder.Services.AddAuthentication().AddJwtBearer(options =>
//{
//	options.TokenValidationParameters = new TokenValidationParameters
//	{
//		ValidateIssuerSigningKey = true,
//		ValidateAudience = false,
//		ValidateIssuer = false,
//		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PTS KMM BMK 1038 MPTM PTS KMM BMK 1038 MPTM"))
//	};
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api.phuongthaoshop.vn v1"));
}

app.MapIdentityApi<UserEntity>();
app.UseHttpsRedirection();

app.UseCors(t => t.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();

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
