using System.Text.Json.Serialization;

namespace MyShop.Core.Common.Models
{
    public class LoginSuccessResponse
    {
        [JsonIgnore]
        public string Token { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public IList<string> Roles { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
