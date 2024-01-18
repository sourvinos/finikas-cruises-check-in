using Microsoft.Extensions.DependencyInjection;

namespace API.Infrastructure.Extensions {

    public static class Cors {

        public static void AddCors(IServiceCollection services) {
            services
                .AddCors(x => x.AddDefaultPolicy(builder => builder
                .WithOrigins("https://localhost:5200", "http://checkin.appfinikascruises.com")
                .AllowAnyHeader()
                .AllowCredentials()
                .AllowAnyMethod()));
        }

    }

}   