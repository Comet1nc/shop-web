using Microsoft.EntityFrameworkCore;
using shop_web.Server.Entities;
using shop_web.Server.Models;


namespace shop_web.Server.Services
{
    public interface IAccountService
    {
        bool RegisterUser(RegisterDto dto);
        int LoginUser(LoginDto dto);
        IEnumerable<Product> GetProductsForUser(int userId);
        bool AddProductToUser(int userId, int productId);
        bool RemoveProductFromUser(int userId, int productId);
        bool RemoveAllProductsFromUser(int userId);

    }

    public class AccountService : IAccountService
    {
        private readonly ProductDbContext _dbContext;

        public AccountService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool RegisterUser(RegisterDto dto)
        {
            var emailInUse = _dbContext.Users.Any(u => u.Email == dto.Email);

            if (emailInUse)
            {
                return false;
            }

            var newUser = new User()
            {
                Name = dto.Name, 
                Email = dto.Email,
                Password = dto.Password
            };

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return true;
        }

        public int LoginUser(LoginDto dto)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == dto.Email);

            if (user == null)
            {
                return -1;
            }

            bool passwordMatch = user.Password == dto.Password;

            if(passwordMatch)
            {
                return user.Id;
            }

            return -1;
        }

        public IEnumerable<Product> GetProductsForUser(int userId)
        {
            var products = _dbContext.UserProducts
                .Where(up => up.UsersId == userId)
                .Select(up => up.Product)
                .ToList();

            return products;
        }

        public bool AddProductToUser(int userId, int productId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return false;
            }

            var product = _dbContext.Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                return false;
            }

            // Проверяем если ли у пользователя данный продукт
            if (_dbContext.UserProducts.Any(up => up.UsersId == userId && up.ProductsId == productId))
            {
                return false;
            }


            // Добавляем продукт
            var userProduct = new UserProducts { UsersId = userId, ProductsId = productId };
            _dbContext.UserProducts.Add(userProduct);
            _dbContext.SaveChanges();

            return true;
        }

        public bool RemoveProductFromUser(int userId, int productId)
        {
            
            var user = _dbContext.Users.Include(u => u.UserProducts).FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return false;
            }

            var userProduct = user.UserProducts.FirstOrDefault(up => up.ProductsId == productId);

            if (userProduct != null)
            {
                // Remove the UserProduct from the user's collection
                user.UserProducts.Remove(userProduct);
                _dbContext.SaveChanges();

                return true;
            }

            return false;
        }

        public bool RemoveAllProductsFromUser(int userId)
        {

            var user = _dbContext.Users.Include(u => u.UserProducts).FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                return false;
            }

            user.UserProducts.RemoveAll(e => true);
            _dbContext.SaveChanges();
            return true;

        }
    }
}
