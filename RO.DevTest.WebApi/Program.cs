using Microsoft.AspNetCore.Identity;
using RO.DevTest.Application;
using RO.DevTest.Application.Contracts.Infrastructure;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Infrastructure.Abstractions;
using RO.DevTest.Persistence;
using RO.DevTest.Persistence.IoC;
using FluentValidation; 
using RO.DevTest.Application.Features.User.Commands.CreateUserCommand; // Adicione este using

namespace RO.DevTest.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddPersistence(builder.Configuration);

        builder.Services.AddIdentity<User, IdentityRole>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 8;
            options.User.RequireUniqueEmail = true;
        })
        .AddEntityFrameworkStores<DefaultContext>()
        .AddDefaultTokenProviders();

        builder.Services.AddScoped<IIdentityAbstractor, IdentityAbstractor>();

        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(ApplicationLayer).Assembly,
                typeof(Program).Assembly
            );
        });

        builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
      
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        if (app.Environment.IsDevelopment())
        {
            app.MapGet("/debug/routes", () =>
            {
                var endpoints = app.Services.GetRequiredService<EndpointDataSource>();
                return endpoints.Endpoints
                    .OfType<RouteEndpoint>()
                    .Select(e => new {
                        Method = e.Metadata.GetMetadata<HttpMethodMetadata>()?.HttpMethods?.FirstOrDefault() ?? "ANY",
                        Path = e.RoutePattern.RawText ?? string.Empty
                    });
            });
        }

        app.Run();
    }
}