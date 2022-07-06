namespace MyShop.Core.Entities
{
    public class Discount : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Percentage { get; set; }

        public virtual Product Product { get; set; }
    }
}
