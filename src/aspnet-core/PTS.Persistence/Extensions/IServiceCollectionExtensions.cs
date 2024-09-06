
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Services;
using PTS.Data;
using PTS.Domain.Entities;
using PTS.Persistence.Repositories;
using PTS.Persistence.Repository;
using PTS.Persistence.Services;

namespace PTS.Persistence.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddAppDbContext(configuration);
		}

		public static void AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<ApplicationDbContext>(options =>
			   options.UseSqlServer(connectionString,
				   builder =>
				   {
					   builder.MigrationsAssembly("PTS.Persistence");
				   }), ServiceLifetime.Scoped);
			services.AddIdentity<UserEntity, RoleEntity>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;
				options.User.RequireUniqueEmail = true;
			})
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();
		//	services.AddIdentityApiEndpoints<UserEntity>().AddEntityFrameworkStores<ApplicationDbContext>();
			services.AddTransient<IVoucherRepository, VoucherRepository>();
			services.AddTransient<IVoucherRepository, VoucherRepository>();
			services.AddTransient<IProductDetailRepository, ProductDetailRepository>();
			services.AddTransient<ISerialRepository, SerialRepository>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<ICartRepository, CartRepository>();
			services.AddTransient<ICartDetailRepository, CartDetailRepository>();
			services.AddTransient<IBillRepository, BillRepository>();
			services.AddTransient<IBillDetailRepository, BillDetailRepository>();
			//services.AddTransient<IUserService, UserService>();
			services.AddTransient<IAccountService, AccountService>();
			services.AddTransient<ICartService, CartService>();
			services.AddTransient<IBillService, BillService>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
           services.AddScoped<IVnPayService, VnPayService>();
        }
	}
}
