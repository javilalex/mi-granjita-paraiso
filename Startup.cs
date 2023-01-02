using Mi_Granjita_Paraiso.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;
using VueCliMiddleware;

namespace Mi_Granjita_Paraiso
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString("defaultConnection");

            //AutoMapper Service
            services.AddAutoMapper(typeof(Startup));

            //Configuracion App Cliente
            services.AddSpaStaticFiles(opt => opt.RootPath = "app/dist");

            //Remover referencias circulares
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

            //Database Service
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            //Identity Service
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });

            services.AddAuthorization()
                    .AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer(options =>
                    {
                        options.SaveToken = true;
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = configuration["Jwt:Issuer"],
                            ValidAudience = configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                        };
                    });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var assemblyVersion = GetAssemblyVersion();

                c.SwaggerDoc(assemblyVersion, new OpenApiInfo
                {
                    Version = assemblyVersion,
                    Title = "Mi Granjita Paraiso API Documentation",
                });

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                c.UseAllOfForInheritance();
                c.SelectSubTypesUsing(baseType => typeof(Startup).Assembly.GetTypes().Where(type => type.IsSubclassOf(baseType)));
                c.MapType<Dictionary<Enums.ModelTypes, List<string>>>(() => new OpenApiSchema());
                c.SchemaFilter<DictionaryTKeyEnumTValueSchemaFilter>();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string command = String.Empty;

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    var assemblyVersion = GetAssemblyVersion();

                    options.SwaggerEndpoint($"/swagger/{assemblyVersion}/swagger.json", assemblyVersion);
                    options.RoutePrefix = string.Empty;
                });
                command = "serve";
            }
            // PRODUCTION uses webpack static files
            app.UseSpaStaticFiles();

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapToVueCliProxy(
                    "{*path}",
                    new SpaOptions { SourcePath = "app" },
                    npmScript: command,
                    regex: "Compiled successfully",
                    forceKill: true,
                    wsl: false // Set to true if you are using WSL on windows. For other operating systems it will be ignored
               );
            });
        }

        private string GetAssemblyVersion()
        {
            var assembly = Assembly.GetEntryAssembly();
            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            return $"V{version.InformationalVersion}";
        }
    }
}

// DictionaryTKeyEnumTValueSchemaFilter.cs
public class DictionaryTKeyEnumTValueSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        // Only run for fields that are a Dictionary<Enum, TValue>
        if (!context.Type.IsGenericType || !context.Type.GetGenericTypeDefinition().IsAssignableFrom(typeof(Dictionary<,>)))
        {
            return;
        }

        var keyType = context.Type.GetGenericArguments()[0];
        var valueType = context.Type.GetGenericArguments()[1];

        if (!keyType.IsEnum)
        {
            return;
        }

        schema.Type = "object";
        schema.Properties = keyType.GetEnumNames().ToDictionary(name => name,
    name => context.SchemaGenerator.GenerateSchema(valueType,
      context.SchemaRepository));
    }
}
