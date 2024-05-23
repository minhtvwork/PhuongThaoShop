using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PTS.Core.Repositories;
using PTS.Infrastructure.Repositories;
using PTS.Host;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using PTS.Core.Services;
using PTS.Infrastructure.Services;
using PTS.Data;
using PTS.Host.AppCore.Request;
using PTS.Infrastructure.Repository;

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
#region Đăng ký MediatR
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(PagingListVoucherRequestHandler).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCartByUserHandler).Assembly));
#endregion

//#region Đăng ký DI
builder.Services.AddScoped<ApplicationDbContext, ApplicationDbContext>();

//builder.Services.AddTransient<IAllRepository<CpuEntity>, AllRepository<CpuEntity>>();
builder.Services.AddTransient<IRamRepository, RamRepository>();
builder.Services.AddTransient<ICpuRepository, CpuRepository>();
builder.Services.AddTransient<IVoucherRepository, VoucherRepository>();
builder.Services.AddTransient<IColorRepository, ColorRepository>();
builder.Services.AddTransient<IVoucherRepository, VoucherRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IHardDriveRepository, HardDriveRepository>();
builder.Services.AddTransient<IManagePostRepository, ManagePostRepository>();
builder.Services.AddTransient<IProductDetailRepository, ProductDetailRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
builder.Services.AddTransient<IScreenRepository, ScreenRepository>();
builder.Services.AddTransient<ISerialRepository, SerialRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICartRepository, CartRepository>();
builder.Services.AddTransient<ICartDetailRepository, CartDetailRepository>();
builder.Services.AddTransient<IBillRepository, BillRepository>();
builder.Services.AddTransient<IBillDetailRepository, BillDetailRepository>();
//builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IBillService, BillService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "api.phuongthaoshop.vn", Version = "v1" });
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "api.phuongthaoshop.vn.xml");
    c.IncludeXmlComments(filePath);
});
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("PTS KMM BMK 1038 MPTM PTS KMM BMK 1038 MPTM"))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api.phuongthaoshop.vn v1"));
}

app.UseHttpsRedirection();

app.UseCors(t => t.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseAuthorization();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
