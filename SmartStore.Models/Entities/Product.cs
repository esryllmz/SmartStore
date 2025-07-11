
using SmartStore.Core.Entities;

namespace SmartStore.Models.Entities
{
    public class Product : Entity<int>
    {
        public  string Name { get; set; }
        public  string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
