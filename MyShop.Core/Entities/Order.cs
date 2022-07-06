namespace MyShop.Core.Entities
{
    public class Order : BaseEntity<int>
    {
        public string? CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual ApplicationUser? Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
