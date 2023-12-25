using Microsoft.IdentityModel.Tokens;
using shop_web.Server.Entities;
using shop_web.Server.Models;

namespace shop_web.Server.Services
{
    public interface IProductService
    {
        void Create(ProductDto dto);
        IEnumerable<Product> GetAll();
        public bool Delete(int id);
        public bool Update(ProductDto dto, int id);

    }

    public class ProductService : IProductService
    {
        private readonly ProductDbContext _dbContext;

        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            var isNull = _dbContext.Products.IsNullOrEmpty();
            if (isNull)
            {
                return null;
            }
            var tasks = _dbContext.Products.ToList();

            return tasks;
        }

        public void Create(ProductDto dto)
        {

            var task = new Product()
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Count = dto.Count,
            };

            _dbContext.Add(task);
            _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var task = _dbContext.Products.FirstOrDefault(t => t.Id == id);

            if (task is null)
            {
                return false;
            }

            _dbContext.Products.Remove(task);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Update(ProductDto dto, int id)
        {
            var task = _dbContext.Products.FirstOrDefault(t => t.Id == id);

            if (task is null)
            {
                return false;
            }

            task.Name = dto.Name;
            task.Description = dto.Description;
            task.Price = dto.Price;
            task.Count = dto.Count;

            _dbContext.SaveChanges();

            return true;
        }
    }
}
