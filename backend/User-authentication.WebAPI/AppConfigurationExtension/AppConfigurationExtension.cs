using System.Text.Json.Serialization;
using User_authentication.BLL.Service;

namespace User_authentication.WebAPI.AppConfigurationExtension
{
    public class AppConfigurationExtension
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement);

            services.AddCors();

            services
                .AddScoped<AuthService>();
        }
    }
}
