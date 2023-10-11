using KAMU.API.Infrastructure.Database;
using KAMU.API.Infrastructure.Repositories;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using KAMU.API.Infrastructure.Services.Db;
using KAMU.API.Infrastructure.Services.User;
using KAMU.API.Infrastructure.Services.Authorisation;
using KAMU.API.Infrastructure.Services.Security;
using KAMU.API.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using KAMU.API.Infrastructure.Services.Login;
using KAMU.API.Infrastructure.Services.Deployment;
using Microsoft.OpenApi.Models;
using KAMU.API.Infrastructure.Services.Organization;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;

namespace KAMU.API.Infrastructure.Extensions
{
    /// <summary>
    /// A service to register all dependencies in the application
    /// </summary>
    public static class DependencyService
    {
        /// <summary>
        /// Sets up dependencies using the service collection and application settings
        /// </summary>
        /// <param name="serviceCollection">Specifies the contract for a collection of service descriptors</param>
        /// <param name="appSettings">Manages application settings</param>
        public static void SetUpDependencies(this IServiceCollection serviceCollection, ApplicationSettings appSettings)
        {
            serviceCollection.AddSingleton((_) => new SessionFactory(appSettings.ConnectionString).GetSession());
            serviceCollection.AddScoped<IPasswordManager, PasswordManager>();
            serviceCollection.AddScoped<IAccessManager, AccessManager>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<ISuperAdminRepository, SuperAdminRepository>();
            serviceCollection.AddScoped<IUserInstructorRepository, InstructorRepository>();
            serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
            serviceCollection.AddTransient<IUserContext, UserContext>();
            serviceCollection.AddScoped<IOrganisationRepository, OrganisationRepository>();
            serviceCollection.AddScoped<IDbService, DbService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<ILoginService, LoginService>();
            serviceCollection.AddScoped<IOrganisationService, OrganisationService>();
            serviceCollection.AddSingleton((_) => appSettings.DeploymentConfiguration);
            serviceCollection.AddSingleton((_) => appSettings.TokenSecret);
            serviceCollection.AddScoped<IDeploymentService, DeploymentService>();
            serviceCollection.AddScoped<ITokenManager, TokenManager>();
            serviceCollection.AddLogging();
            serviceCollection.AddScoped<Validation>();
        }

        /// <summary>
        /// Sets up security configuration
        /// </summary>
        /// <param name="serviceCollection">Specifies the contract for a collection of service descriptors</param>
        /// <param name="tokenSecret">Manages the token secrets</param>
        public static void AddSecurityConfiguration(this IServiceCollection serviceCollection, ITokenSecret tokenSecret )
        {
            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                  ValidateIssuer = false,
                  ValidateAudience = false,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = tokenSecret.Issuer,
                  ValidAudience = tokenSecret.Audience,
                  ClockSkew = TimeSpan.Zero,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecret.SecretKey))
               };
            });
            serviceCollection.AddAuthorization(o =>
            {
                o.AddPolicy(HasRoleAttribute.POLICY, p =>
                {
                    p.Requirements.Add(new HasRoleAuthorisationRequirement());
                    p.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                });
                o.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            });
            serviceCollection.AddScoped<IAuthorizationHandler, HasRoleAuthorisationHandler>();
        }

        /// <summary>
        ///  Seeds super admin to the database
        /// </summary>
        /// <param name="serviceCollection">Specifies the contract for a collection of service descriptors</param>
        public static void SeedDatabase(this IServiceCollection serviceCollection)
        {
            using var serviceProvider = serviceCollection.BuildServiceProvider();
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger("SeedDatabase");
            try
            {
                var deploymentService = serviceProvider.GetService<IDeploymentService>();
                var response = deploymentService.CreateSuperAdmin().Result;
                logger.LogInformation("Seeding Statuscode: {statuscode} , Error : {error}", response.StatusCode, response.Errors.FirstOrDefault());
            }
            catch (Exception ex)
            {
                logger.LogError("Error message {errorMessage}", ex.Message);
            }
        }

        /// <summary>
        /// Sets up Swagger configurations
        /// </summary>
        /// <param name="serviceCollection">Specifies the contract for a collection of service descriptors</param>
        public static void SwaggerConfiguration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "bearer",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
