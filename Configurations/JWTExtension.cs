using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Skill_Hub.Configurations
{
    public static class JWTExtension
    {
        public static IServiceCollection AddAuthentication(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            // Get JWT configuration
            var jwtConfig = configuration.GetSection("Jwt");
            var jwtKey = jwtConfig["Key"];

            // Add some validation and logging
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new ArgumentException("JWT Key is not configured in appsettings.json");
            }

            Console.WriteLine($"JWT Key configured: {jwtKey.Substring(0, Math.Min(10, jwtKey.Length))}...");


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                    ClockSkew = TimeSpan.Zero
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Auth failed: {context.Exception.Message}");
                        Console.WriteLine($"Exception type: {context.Exception.GetType().Name}");
                        if (context.Exception.InnerException != null)
                        {
                            Console.WriteLine($"Inner exception: {context.Exception.InnerException.Message}");
                        }
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token validated successfully");
                        var claims = context.Principal?.Claims;
                        if (claims != null)
                        {
                            foreach (var claim in claims)
                            {
                                Console.WriteLine($"Claim: {claim.Type} = {claim.Value}");
                            }
                        }
                        return Task.CompletedTask;
                    },
                    OnChallenge = context =>
                    {
                        Console.WriteLine($"Auth challenge triggered: {context.Error}");
                        Console.WriteLine($"Error description: {context.ErrorDescription}");
                        Console.WriteLine($"Auth header: {context.Request.Headers["Authorization"].FirstOrDefault()}");
                        return Task.CompletedTask;
                    },
                    OnMessageReceived = context =>
                    {
                        var token = context.Request.Headers["Authorization"].FirstOrDefault();
                        Console.WriteLine($"Token received: {(string.IsNullOrEmpty(token) ? "No token" : token.Substring(0, Math.Min(20, token.Length)) + "...")}");
                        return Task.CompletedTask;
                    }
                };
            });
            return services;

        }
    }
}


