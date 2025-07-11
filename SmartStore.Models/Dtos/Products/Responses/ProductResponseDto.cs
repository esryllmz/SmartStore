using SmartStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Models.Dtos.Products.Responses
{
    public sealed record ProductResponseDto
    {

        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public int CategoryId { get; init; }
        public string Category { get; init; } = string.Empty;

    }
}
