
using SmartStore.Core.Entities;

namespace SmartStore.Models.Entities
{
    public class Category: Entity<int>
    {
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; }

    }
}
