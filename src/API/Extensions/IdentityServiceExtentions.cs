using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public class IdentityServiceExtentions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection service,
            IConfiguration config)
        {
            service.AddIdentityCore<AppUser>(opt => {
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<DataContext>();

            var key = new SymmetricSecurityKey(Encoding.UTF.GetBytes("super secret key"))

            services.AddAuthentication(JwtBearDefaults.AddAuthenticatioSheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParametrs = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key;
                        ValidateIssure = false,
                        ValidateAudience = false
                    };
                    opr.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"]
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) && (path.StartWithSegments("/chat"))) 
                            {
                                countext.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    }
                });

            services.AddScoped<TokenService>();

            return service;
        }

    }
}