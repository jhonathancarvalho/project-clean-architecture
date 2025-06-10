namespace CleanArchitecture.API.Extensions
{
    public static class CorsPolicyExtensions
    {
        private const string DefaultCorsPolicy = "DefaultCorsPolicy";

        public static void ConfigureCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: DefaultCorsPolicy, builder =>
                {
                    builder
                        .AllowAnyOrigin()    
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        public static string GetCorsPolicyName() => DefaultCorsPolicy;
    }
}