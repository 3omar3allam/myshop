using MyShop.Core.Interfaces;

namespace MyShop.Core.Entities
{
    public class Product : BaseEntity<int>, ISoftDeletable
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Category Category { get; set; }
        public virtual Discount? Discount { get; set; }
    }
}
