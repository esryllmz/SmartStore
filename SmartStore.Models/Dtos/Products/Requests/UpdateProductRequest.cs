using SmartStore.Models.Entities;

namespace SmartStore.Models.Dtos.Products.Requests;

public sealed record UpdateProductRequest(int Id, string Name, string Description, decimal Price, int CategoryId);

