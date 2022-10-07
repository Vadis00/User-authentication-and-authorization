using System.Text.Json.Serialization;
using User_authentication.BLL.Service;
using User_authentication.Identity.Model;

namespace User_authentication.WebAPI.AppConfigurationExtension
{
    public static class AppConfigurationExtension
    {
        public static IServiceCollection ConfigureAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            var authOptionsConfiguration = configuration.GetSection("Auth");
            services.Configure<AuthOptions>(authOptionsConfiguration);

            return services;
        }

        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services
                .ConfigureAuthServices(configuration)
                .AddMvc();

            services
                .AddControllers()
                .AddJsonOptions(options =>
                     options.JsonSerializerOptions.UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement);

            services.AddCors();

            services
                .AddScoped<AuthService>();
        }
    }
}
