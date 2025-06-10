using CleanArchitecture.API.Extensions;
using CleanArchitecture.Infrastructure.Extensions;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Application.UseCases.Users.CreateUser;
using CleanArchitecture.Domain.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureApplicationApp(typeof(CreateUserHandler).Assembly);
builder.Services.ConfigureCorsPolicy();


builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateTimeOffsetJsonConverter("dd/MM/yyyy"));
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = "swagger"; 
    });
}

app.UseHttpsRedirection();

app.UseCors(CorsPolicyExtensions.GetCorsPolicyName());

app.UseAuthorization();

app.MapControllers();

app.Run();