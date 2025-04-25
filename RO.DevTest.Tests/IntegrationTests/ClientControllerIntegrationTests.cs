using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net.Http.Json;
using Bogus;
using System.Collections.Generic;
using System.Linq;
using RO.DevTest.WebApi; // Importe o namespace da sua Web API para o WebApplicationFactory

public class ClientControllerIntegrationTests : WebApplicationFactory<Program>
{
    private readonly HttpClient _client;
    private readonly Faker<Client> _clientFaker;

    public ClientControllerIntegrationTests()
    {
        _client = CreateClient();
        _clientFaker = new Faker<Client>("pt_BR")
            .RuleFor(c => c.Name, f => f.Name.FullName())
            .RuleFor(c => c.Email, f => f.Internet.Email());
    }

    [Fact]
    public async Task Get_ClientsEndpoint_ShouldReturnOkAndNotEmptyListWithValidClients()
    {
        // Arrange

        // Act
        var response = await _client.GetAsync("/api/client");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        var clients = await response.Content.ReadFromJsonAsync<IEnumerable<Client>>();
        clients.Should().NotBeNullOrEmpty();

        var firstClient = clients.First();
        firstClient.Name.Should().NotBeNullOrWhiteSpace();
        firstClient.Email.Should().Contain("@");
    }

    [Fact]
    public async Task Post_CreateClientEndpoint_ShouldReturnCreatedAndClientObjectWithGeneratedData()
    {
        // Arrange
        var newClient = _clientFaker.Generate();

        // Act
        var response = await _client.PostAsJsonAsync("/api/client", newClient);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
        var createdClient = await response.Content.ReadFromJsonAsync<Client>();
        createdClient.Should().NotBeNull();
        createdClient.Name.Should().Be(newClient.Name);
        createdClient.Email.Should().Be(newClient.Email);
        createdClient.Id.Should().NotBeEmpty();
    }
}

// Supondo que você tenha uma classe Client em seu projeto de domínio
public class Client
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}