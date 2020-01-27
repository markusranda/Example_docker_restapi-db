using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Supermarket.API.Domain.Models.Auth;
using Supermarket.API.Domain.Models.Auth.Token;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Security;
using Supermarket.API.Domain.Services;
using Supermarket.API.Persistence.Contexts;
using Supermarket.API.Persistence.Repositories;
using Supermarket.API.Security.Tokens;
using Supermarket.API.Services;
using TokenHandler = Supermarket.API.Security.Tokens.TokenHandler;

namespace Supermarket.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddDbContext<AppDbContext>(options =>
            {
                // options.UseInMemoryDatabase("supermarket-api-in-memory");
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
            });
            
            services.AddSingleton<IPasswordHasher, Security.Hashing.PasswordHasher>();
            services.AddSingleton<ITokenHandler, TokenHandler>();

            // Bind all repos
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Bind all services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            var tokenOptions = Configuration.GetSection("TokenOptions")
                .Get<TokenOptions>();

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.SaveToken = true;
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        IssuerSigningKey = signingConfigurations.Key,
                        ClockSkew = TimeSpan.Zero
                    };
                    // jwtBearerOptions.Events = new JwtBearerEvents()
                    // {
                    //     OnChallenge = context =>
                    //     {
                    //         Console.WriteLine("OnChallenge: " + context.Response.StatusCode);
                    //         return Task.CompletedTask;
                    //     },
                    //     OnAuthenticationFailed = context =>
                    //     {
                    //         Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                    //         return Task.CompletedTask;
                    //     },
                    //     OnForbidden = context =>
                    //     {
                    //         Console.WriteLine("OnForbidden: " + context.Response.StatusCode);
                    //         return Task.CompletedTask;
                    //     },
                    //     OnMessageReceived = context =>
                    //     {
                    //         Console.WriteLine("OnMessageReceived: " + context.Response.StatusCode);
                    //         return Task.CompletedTask;
                    //     },
                    //     OnTokenValidated = context =>
                    //     {
                    //         Console.WriteLine("OnTokenValidated: " + context.Response.StatusCode);
                    //         return Task.CompletedTask;
                    //     }
                    // };
                });

            // May be wrong to use current parameter, was added to resolve error
            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); // fant den her etter 3 daga

            app.UseAuthorization(); // trudd den her va nokk, veldig like navn...

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}