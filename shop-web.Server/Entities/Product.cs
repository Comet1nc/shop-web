using System.ComponentModel.DataAnnotations;

namespace shop_web.Server.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }

        public List<UserProducts> UserProducts { get; set; } = new List<UserProducts>();
        public List<User> Users { get; set; } = new List<User>();
    }
}
