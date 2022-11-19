using Backend_ClothingApp.Data;
using Backend_ClothingApp.Models.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend_ClothingApp.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;
        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }
        public ProductVM Create(AddProductModel productVM)
        {
            Product product = new Product
            {
                Name = productVM.Name,
                Description = productVM.Description,
                Price = productVM.Price,
                ImgUrl = productVM.ImgUrl
            };
            _context.Products.Add(product);

            _context.SaveChanges();

            return new ProductVM(product);
        }

        public bool Delete(string id)
        {
            Product product = _context.Products.SingleOrDefault(product => product.id.ToString() == id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return true;
        }

        public List<ProductVM> GetAll()
        {
            List<ProductVM> productVMs = _context.Products.Select(product => new ProductVM(product)).ToList();

            return productVMs;
        }

        public ProductVM GetById(string id)
        {
            Product product = _context.Products.SingleOrDefault(product => product.id.ToString() == id);

            if (product == null)
            {
                return null;
            }

            return new ProductVM(product);
        }

        public bool Update(string id, UpdateProductModel productVM)
        {
            Product product = _context.Products.SingleOrDefault(product => product.id.ToString() == id);

            if (product == null)
            {
                return false;
            }

            product.Name = productVM.Name;
            product.Price = productVM.Price;
            product.Description = productVM.Description;
            product.ImgUrl = productVM.ImgUrl;

            _context.Update(product);
            _context.SaveChanges();

            return true;
        }
    }
}
