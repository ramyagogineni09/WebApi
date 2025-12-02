//using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Webapi.Data;
using Webapi.Models;

namespace Webapi.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,
            IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection")
              ?? throw new InvalidOperationException("Connection string 'DefaultConnection' notfound");
            services.AddDbContext<DataContext>(options=>options.UseSqlServer(connectionString));

            //configure sessions options
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;

            });

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<DataContext>()
            //    .AddDefaultTokenProviders();



            services.AddControllers();
            services.AddCors();

            return services;

        }
    }
}
