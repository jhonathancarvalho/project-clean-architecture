using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Context;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.Infrastructure.Secutiry;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi configurada.");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString, sqlOptions =>
                    sqlOptions.MigrationsAssembly("CleanArchitecture.Infrastructure")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
        }
    }
}