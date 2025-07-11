using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Models.Dtos.Products.Responses
{
    public sealed record CreatedProductResponseDto
    {
        public int Id { get; init; }
    }
}
