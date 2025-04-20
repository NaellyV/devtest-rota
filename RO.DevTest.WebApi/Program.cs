using RO.DevTest.Application;
using RO.DevTest.Infrastructure.IoC;
using RO.DevTest.Persistence.IoC;

namespace RO.DevTest.WebApi;

public class Program {
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Injetando as dependências da persistência e passando a configuração
        builder.Services.InjectPersistenceDependencies(builder.Configuration)
            .InjectInfrastructureDependencies();

        // Adicionando o MediatR
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(ApplicationLayer).Assembly,
                typeof(Program).Assembly
            );
        });

        var app = builder.Build();

        // Configurar o pipeline de requisições HTTP
        if (app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

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
