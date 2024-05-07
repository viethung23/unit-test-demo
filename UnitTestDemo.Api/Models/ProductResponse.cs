namespace UnitTestDemo.Api.Models;

public record ProductResponse(
    int Id,
    string Name,
    string Description,
    decimal Price
    );
