namespace SmartStore.Models.Dtos.Products.Requests;

public sealed record CreateProductRequest(string Name, string Description, decimal Price, int CategoryId);
