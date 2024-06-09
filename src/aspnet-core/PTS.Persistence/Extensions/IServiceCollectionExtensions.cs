
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PTS.Application.Interfaces.Repositories;
using PTS.Core.Services;
using PTS.Data;
using PTS.Persistence.Repositories;
using PTS.Persistence.Repository;
using PTS.Persistence.Services;

namespace PTS.Persistence.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
		{
        //    services.AddIdentityDbContext(configuration);
			services.AddPhapDienDocItemsDbContext(configuration);
		}
        //public static void AddIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
        //{
        //    var connectionString = configuration.GetConnectionString("IdentityConnection");

        //    services.AddDbContext<ICIdentityDbContext>(options =>
        //       options.UseSqlServer(connectionString,
        //           builder => builder.MigrationsAssembly("IC.WebCMS")));

        //    services
        //        .AddTransient<IIdentityUnitOfWork, IdentityUnitOfWork>()
        //        .AddTransient<IUserRepo, UserRepo>()
        //        .AddTransient<IRoleRepo, RoleRepo>()
        //        .AddTransient<IUserRoleRepo, UserRoleRepo>()
        //        .AddTransient<ISysFunctionRepo, SysFunctionRepo>()
        //        .AddTransient<IFieldRepo, FieldRepo>();
        //}

		public static void AddPhapDienDocItemsDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<ApplicationDbContext>(options =>
			   options.UseSqlServer(connectionString,
				   builder =>
				   {
					   builder.MigrationsAssembly("PTS.WebAPI");
				   }));
			//services.AddTransient<IAllRepository<CpuEntity>, AllRepository<CpuEntity>>();
			services.AddTransient<IRamRepository, RamRepository>();
			services.AddTransient<ICpuRepository, CpuRepository>();
			services.AddTransient<IVoucherRepository, VoucherRepository>();
			services.AddTransient<IColorRepository, ColorRepository>();
			services.AddTransient<IVoucherRepository, VoucherRepository>();
			services.AddTransient<IContactRepository, ContactRepository>();
			services.AddTransient<IHardDriveRepository, HardDriveRepository>();
			services.AddTransient<IManagePostRepository, ManagePostRepository>();
			services.AddTransient<IProductDetailRepository, ProductDetailRepository>();
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
			services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
			services.AddTransient<IScreenRepository, ScreenRepository>();
			services.AddTransient<ISerialRepository, SerialRepository>();
			services.AddTransient<IRoleRepository, RoleRepository>();
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
		}
	}
}
