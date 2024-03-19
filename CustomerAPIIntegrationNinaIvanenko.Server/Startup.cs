using Microsoft.EntityFrameworkCore;

namespace DBTest.Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
            => services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("Server=HOME-LT;Database=CustomerAPIIntegrationDatabaseNinaIvanenko;User Id=dev;Password=it310"));

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}