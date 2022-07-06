using Microsoft.AspNetCore.Identity;

namespace MyShop.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
            Orders = new List<Order>();
        }

        public string DisplayName { get; set; }

        public virtual IList<Order> Orders { get; set; }
    }
}
