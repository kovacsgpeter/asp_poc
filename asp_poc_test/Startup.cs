using asp_poc.service;
using Microsoft.Extensions.DependencyInjection;

namespace asp_poc_test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<UserService>();
        }
    }
}