namespace MyShop.Core.Entities
{
    public class Category : BaseEntity<int>
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public string Name { get; set; }
        public IList<Product> Products { get; set; }
    }
}
