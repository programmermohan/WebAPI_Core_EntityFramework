using IMS.Web.API.Services;
using IMS.Web.Business.Common;
using IMS.Web.Business.Implementation;
using IMS.Web.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Web.API.Common
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("IMSConnectionStr")));

            services.AddSingleton<ITokenService, TokenService>(); 
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped < IStudentService, StudentService>();            
        }
    }
}
