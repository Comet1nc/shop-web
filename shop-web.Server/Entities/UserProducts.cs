namespace shop_web.Server.Entities
{
    public class UserProducts
    {
        public int ProductsId { get; set; }
        public int UsersId { get; set; }
        public Product Product { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
