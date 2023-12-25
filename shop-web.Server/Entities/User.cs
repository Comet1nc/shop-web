using System.ComponentModel.DataAnnotations;

namespace shop_web.Server.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        public List<UserProducts> UserProducts { get; set; } = new List<UserProducts>();
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
